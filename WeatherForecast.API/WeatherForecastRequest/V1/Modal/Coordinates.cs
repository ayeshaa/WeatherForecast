using Newtonsoft.Json;

namespace WeatherForecast.API.WeatherforecastRequest.V1.Modal
{
    public class Coordinates
    {
        [JsonProperty("lat")]
        public float Latitude
        {
            get; set;
        }
        [JsonProperty("lon")]
        public float Longitude
        {
            get; set;
        }
    }
}
