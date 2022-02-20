using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WeatherForecast.API.WeatherforecastRequest.V1.Modal
{
    public class DefaultResponse
    {
        [Required]
        [JsonProperty("cod")]
        public int StatusCode { get; set; }

        [Required]
        [JsonProperty("message")]
        public string StatusMessage { get; set; }
        [JsonProperty("cnt")]
        public int CNT { get; set; }

        public bool Success { get; set; }
        [JsonProperty("list")]
        public List<WeatherResponse> WeatherData
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
