namespace WeatherForecast.Service.Services
{
    public interface IWeatherForecastSchedularService
    {
        void ExecuteService();
        void FetchLatestData();
    }
}
