using MongoDB.Bson;
using Newtonsoft.Json;

namespace WeatherForecast.API.WeatherforecastRequest.V1.Modal
{
    public class City
    {
        [JsonProperty("id")]
        public ObjectId Id
        {
            get; set;
        }
        [JsonProperty("name")]
        public string Name
        {
            get; set;
        }
        [JsonProperty("coord")]
        public Coordinates Coordinates
        {
            get; set;
        }
        [JsonProperty("country")]
        public string Country
        {
            get; set;
        }
        [JsonProperty("population")]
        public int Population
        {
            get; set;
        }
        [JsonProperty("timezone")]
        public int TimeZone
        {
            get; set;
        }
        [JsonProperty("sunrise")]
        public int Sunrise
        {
            get; set;
        }
        [JsonProperty("sunset")]
        public int Sunset
        {
            get; set;
        }
    }
}
