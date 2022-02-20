using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace WeatherForecast.API.WeatherforecastRequest.V1.Modal
{
    public class WeatherResponse
    {
        [JsonProperty("dt")]
        public int DT
        {
            get; set;
        }
        [JsonProperty("main")]
        public Main Main
        {
            get; set;
        }
        [JsonProperty("weather")]
        public List<Weather> Weather
        {
            get; set;
        }
        [JsonProperty("clouds")]
        public Clouds Clouds
        {
            get; set;
        }
        [JsonProperty("wind")]
        public Wind Wind
        {
            get; set;
        }
        [JsonProperty("visibility")]
        public int Visibility
        {
            get; set;
        }
        [JsonProperty("pop")]
        public float Pop
        {
            get; set;
        }
        [JsonProperty("sys")]
        public Sys Sys
        {
            get; set;
        }
        [JsonProperty("dt_txt")]
        public DateTime? DateTimeText
        {
            get; set;
        }
    }
}
