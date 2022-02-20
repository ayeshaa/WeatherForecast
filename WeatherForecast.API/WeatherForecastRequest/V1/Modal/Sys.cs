using Newtonsoft.Json;

namespace WeatherForecast.API.WeatherforecastRequest.V1.Modal
{
    public class Sys
    {
        [JsonProperty("pod")]
        public string Pod
        {
            get; set;
        }
    }

}
