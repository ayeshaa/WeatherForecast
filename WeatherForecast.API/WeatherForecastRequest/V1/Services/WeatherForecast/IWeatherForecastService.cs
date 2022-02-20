using WeatherForecast.API.WeatherforecastRequest.V1.Modal;

namespace WeatherForecast.API.WeatherforecastRequest.V1.Services.WeatherForecast
{
    public interface IWeatherForecastService
    {
        WeatherDataResponse GetStoredWeatherData();
        object GetWeatherForecastData();
    }
}
