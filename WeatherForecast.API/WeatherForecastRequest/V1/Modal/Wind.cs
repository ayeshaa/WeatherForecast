using Newtonsoft.Json;

namespace WeatherForecast.API.WeatherforecastRequest.V1.Modal
{
    public class Wind
    {
        [JsonProperty("speed")]
        public float Speed
        {
            get; set;
        }
        [JsonProperty("deg")]
        public int Deg
        {
            get; set;
        }
        [JsonProperty("gust")]
        public float Gust
        {
            get; set;
        }
    }
}
