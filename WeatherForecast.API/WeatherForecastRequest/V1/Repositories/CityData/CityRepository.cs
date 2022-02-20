using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherForecast.Data.Entities.City;

namespace WeatherForecast.API.WeatherforecastRequest.V1.Repositories.CityData
{
    public class CityRepository : ICityRepository
    {
        private readonly IMongoCollection<City> collection;

        public CityRepository(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Mongo");
            var url = MongoUrl.Create(connectionString);
            var client = new MongoClient(url);
            var mongoDatabase = client.GetDatabase(url.DatabaseName);
            this.collection = mongoDatabase.GetCollection<City>("City");
        }

        public List<City> Get()
        {
            var city = this.collection.AsQueryable().OrderByDescending(c => c.Id).ToList();
            return city;
        }
        public City Find(ObjectId? id)
        {
            var city = this.collection.AsQueryable().Where(c => c.Id == id).First();
            return city;
        }

        public async Task<City> Insert(City city)
        {
            await this.collection.InsertOneAsync(city);
            return city;
        }

        public City Update(City city)
        {
            var filterToken = Builders<City>.Filter.Eq("Id", city.Id);

            // Update logic for making updates in code/table
            var tokenUpdate = Builders<City>.Update.Set("Id", city.Id);
            this.collection.UpdateOne(filterToken, tokenUpdate);
            return city;
        }
    }
}
