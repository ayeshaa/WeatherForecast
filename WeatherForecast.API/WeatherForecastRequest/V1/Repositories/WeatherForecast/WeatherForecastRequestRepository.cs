using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherForecast.Data.Entities.WeatherData;

namespace WeatherForecast.API.WeatherForecastRequest.V1.Repositories.WeatherForecast
{
    public class WeatherForecastRequestRepository : IWeatherForecastRequestRepository
    {
        private readonly IMongoCollection<WeatherForecastData> collection;

        public WeatherForecastRequestRepository(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Mongo");
            var url = MongoUrl.Create(connectionString);
            var client = new MongoClient(url);
            var mongoDatabase = client.GetDatabase(url.DatabaseName);
            this.collection = mongoDatabase.GetCollection<WeatherForecastData>("WeatherForecastData");
        }
        public List<WeatherForecastData> Get()
        {
            var weatherForecast = this.collection.AsQueryable().OrderByDescending(c => c.Id).ToList();
            return weatherForecast;
        }

        public List<WeatherForecastData> FindbyCity(ObjectId id)
        {
            var weatherForecast = this.collection.AsQueryable().Where(c => c.CityID == id).ToList();
            return weatherForecast;
        }

        public async Task<WeatherForecastData> Insert(WeatherForecastData accessToken)
        {
            await this.collection.InsertOneAsync(accessToken);
            return accessToken;
        }
        public WeatherForecastData Update(WeatherForecastData weatherForecast)
        {
            var filterToken = Builders<WeatherForecastData>.Filter.Eq("Id", weatherForecast.Id);

            // Update logic for making updates in code/table
            var tokenUpdate = Builders<WeatherForecastData>.Update.Set("DT", weatherForecast.DT);
            this.collection.UpdateOne(filterToken, tokenUpdate);
            return weatherForecast;
        }

    }
}
