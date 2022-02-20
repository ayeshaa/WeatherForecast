using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherForecast.Data.Entities.WeatherData;

namespace WeatherForecast.API.WeatherForecastRequest.V1.Repositories.WeatherForecast
{
    public interface IWeatherForecastRequestRepository
    {
        List<WeatherForecastData> Get();
        List<WeatherForecastData> FindbyCity(ObjectId id);
        Task<WeatherForecastData> Insert(WeatherForecastData accessToken);
        WeatherForecastData Update(WeatherForecastData weatherForecast);
    }
}
