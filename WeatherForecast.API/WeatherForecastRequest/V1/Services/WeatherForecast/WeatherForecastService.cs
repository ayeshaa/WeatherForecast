using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using WeatherForecast.API.WeatherforecastRequest.V1.Modal;
using WeatherForecast.API.WeatherforecastRequest.V1.Repositories.CityData;
using WeatherForecast.API.WeatherforecastRequest.V1.Services.WeatherForecastAPI;
using WeatherForecast.API.WeatherForecastRequest.V1.Repositories.WeatherForecast;
using WeatherForecast.Data.Entities.WeatherData;

namespace WeatherForecast.API.WeatherforecastRequest.V1.Services.WeatherForecast
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly IWeatherForecastApiService apiService;
        private readonly IConfiguration configuration;
        private readonly IWeatherForecastRequestRepository repository;
        private readonly ICityRepository cityRepository;

        public WeatherForecastService()
        {
        }

        public WeatherForecastService(IWeatherForecastApiService apiService, IConfiguration configuration, IWeatherForecastRequestRepository repository, ICityRepository cityRepository)
        {
            this.apiService = apiService;
            this.configuration = configuration;
            this.repository = repository;
            this.cityRepository = cityRepository;
        }
        public WeatherDataResponse GetStoredWeatherData()
        {
            var WeatherData = this.repository.Get();
            var res = new WeatherDataResponse();
            res.Weather = new List<WeatherData>();

            try
            {
                foreach (var w in WeatherData)
                {
                    var city = this.cityRepository.Find(w.CityID);
                    res.Weather.Add(new Modal.WeatherData
                    {
                        City = new Modal.City
                        {
                            Country = city.Country,
                            Name = city.Name,
                            Id = city.Id.ToString(),
                            Population = city.Population,
                            Sunrise = city.Sunrise,
                            Sunset = city.Sunset,
                            TimeZone = city.TimeZone,
                            Coordinates = new Coordinates
                            {
                                Latitude = city.Latitude,
                                Longitude = city.Longitude,
                            }
                        },
                        Weather = new WeatherDetails
                        {
                            Clouds = w.Clouds,
                            DateTimeText = w.DateTimeText,
                            DT = w.DT,
                            MainFeelLike = w.MainFeelLike,
                            MainGrandLevel = w.MainGrandLevel,
                            MainHumidity = w.MainHumidity,
                            MainPressure = w.MainPressure,
                            MainSeaLevel = w.MainSeaLevel,
                            MainTemp = w.MainTemp,
                            MainTempKF = w.MainTemp,
                            MainTempMax = w.MainTempMax,
                            MainTempMin = w.MainTempMin,
                            Pop = w.Pop,
                            Pod = w.Pod,
                            Visibility = w.Visibility,
                            WeatherDescription = w.WeatherDescription,
                            Id = w.Id,
                            WeatherIcon = w.WeatherIcon,
                            WeatherId = w.WeatherId,
                            WeatherMain = w.WeatherMain,
                            WindDeg = w.WindDeg,
                            WindGust = w.WindGust,
                            WindSpeed = w.WindSpeed,
                        }
                    });

                }
                res.StatusMessage = "Success";
                res.StatusCode = 200;
                res.Success = true;
            }
            catch (Exception ex)
            {
                res.Success = false;
                res.StatusCode = 503;
                res.StatusMessage = ex.Message;
            }
            return res;
        }
        public object GetWeatherForecastData()
        {
            var endpoint = this.configuration["Endpoint"];
            var appId = this.configuration["AppId"];
            var tempLimit = float.Parse(this.configuration["TempratureLimit"], CultureInfo.InvariantCulture.NumberFormat);
            List<string> cities = this.configuration.GetSection("Locations").Get<List<string>>();

            foreach (var c in cities)
            {
                WeatherForecastData i = new WeatherForecastData();
                Data.Entities.City.City city = new Data.Entities.City.City();

                var forcastData = apiService.FetchWeatherData(c, endpoint, appId);

                city.Country = forcastData.City.Country;
                city.Latitude = forcastData.City.Coordinates.Latitude;
                city.Longitude = forcastData.City.Coordinates.Longitude;
                city.Name = forcastData.City.Name;
                city.Population = forcastData.City.Population;
                city.Sunrise = forcastData.City.Sunrise;
                city.Sunset = forcastData.City.Sunset;
                city.TimeZone = forcastData.City.TimeZone;
                this.cityRepository.Insert(city);

                foreach (var weatherData in forcastData.WeatherData)
                {
                    if (weatherData.Main.Temp > tempLimit)
                    {
                        i.Clouds = weatherData.Clouds.All;
                        i.DateTimeText = weatherData.DateTimeText;
                        i.DT = weatherData.DT;
                        i.Id = i.Id;
                        i.MainFeelLike = weatherData.Main.FeelLike;
                        i.MainGrandLevel = weatherData.Main.GrandLevel;
                        i.MainHumidity = weatherData.Main.Humidity;
                        i.MainPressure = weatherData.Main.Pressure;
                        i.MainSeaLevel = weatherData.Main.SeaLevel;
                        i.MainTemp = weatherData.Main.Temp;
                        i.MainTempKF = weatherData.Main.TempKF;
                        i.MainTempMax = weatherData.Main.TempMax;
                        i.MainTempMin = weatherData.Main.TempMin;
                        i.Visibility = weatherData.Visibility;
                        i.Pod = weatherData.Sys.Pod;
                        i.Pop = weatherData.Pop;

                        foreach (var w in weatherData.Weather)
                        {
                            i.WeatherDescription = i.WeatherDescription + ", " + w.Description;
                            i.WeatherIcon = i.WeatherIcon + ", " + w.Icon;
                            i.WeatherId = i.WeatherId + ", " + w.Id;
                            i.WeatherMain = i.WeatherMain + ", " + w.Main;
                        }

                        i.WindDeg = i.WindDeg + ", " + weatherData.Wind.Deg;
                        i.WindGust = i.WindGust + ", " + weatherData.Wind.Gust;
                        i.WindSpeed = i.WindSpeed + ", " + weatherData.Wind.Speed;
                        i.CityID = city.Id;

                        this.repository.Insert(i);
                    }
                }
            }

            return "Sucessfully Updated!";
        }
    }
}
