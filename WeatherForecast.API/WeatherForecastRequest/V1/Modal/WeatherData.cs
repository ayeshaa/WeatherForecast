using Newtonsoft.Json;

namespace WeatherForecast.API.WeatherforecastRequest.V1.Modal
{
    public class WeatherData
    {
        [JsonProperty("list")]
        public WeatherDetails Weather
        {
            get; set;
        }
        [JsonProperty("city")]
        public City City
        {
            get; set;
        }
    }
}
