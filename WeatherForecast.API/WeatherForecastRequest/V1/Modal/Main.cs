using Newtonsoft.Json;

namespace WeatherForecast.API.WeatherforecastRequest.V1.Modal
{
    public class Main
    {
        [JsonProperty("temp")]
        public float Temp
        {
            get; set;
        }
        [JsonProperty("feels_like")]
        public float FeelLike
        {
            get; set;
        }
        [JsonProperty("temp_min")]
        public float TempMin
        {
            get; set;
        }
        [JsonProperty("temp_max")]
        public float TempMax
        {
            get; set;
        }
        [JsonProperty("pressure")]
        public int Pressure
        {
            get; set;
        }
        [JsonProperty("sea_level")]
        public int SeaLevel
        {
            get; set;
        }
        [JsonProperty("grnd_level")]
        public int GrandLevel
        {
            get; set;
        }
        [JsonProperty("humidity")]
        public int Humidity
        {
            get; set;
        }
        [JsonProperty("temp_kf")]
        public float TempKF
        {
            get; set;
        }
    }
}
