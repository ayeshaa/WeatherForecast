using Newtonsoft.Json;

namespace WeatherForecast.API.WeatherforecastRequest.V1.Modal
{
    public class Clouds
    {
        [JsonProperty("all")]
        public int All
        {
            get; set;
        }
    }
}
