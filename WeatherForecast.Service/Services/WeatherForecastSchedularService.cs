using System;
using WeatherForecast.API.WeatherforecastRequest.V1.Services.WeatherForecast;

namespace WeatherForecast.Service.Services
{
    public class WeatherForecastSchedularService : IWeatherForecastSchedularService
    {
        private readonly IWeatherForecastService service;
        public WeatherForecastSchedularService(IWeatherForecastService service)
        {
            this.service = service;
        }

        public void ExecuteService()
        {
            Console.WriteLine("Sending request!");
            FetchLatestData();
        }

        public void FetchLatestData()
        {
            this.service.GetWeatherForecastData();
        }
    }
}
