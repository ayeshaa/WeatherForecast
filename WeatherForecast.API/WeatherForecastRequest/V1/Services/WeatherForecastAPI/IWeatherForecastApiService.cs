using WeatherForecast.API.WeatherforecastRequest.V1.Modal;

namespace WeatherForecast.API.WeatherforecastRequest.V1.Services.WeatherForecastAPI
{
    public interface IWeatherForecastApiService
    {
        DefaultResponse FetchWeatherData(string city, string endpoint, string appId);
    }
}
