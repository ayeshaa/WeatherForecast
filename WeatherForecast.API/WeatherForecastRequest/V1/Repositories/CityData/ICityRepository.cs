using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherForecast.Data.Entities.City;

namespace WeatherForecast.API.WeatherforecastRequest.V1.Repositories.CityData
{
    public interface ICityRepository
    {
        List<City> Get();
        City Find(ObjectId? id);
        Task<City> Insert(City city);
        City Update(City city);
    }
}
