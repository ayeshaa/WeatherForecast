using MongoDB.Bson;
using System;

namespace WeatherForecast.Data.Entities.WeatherData
{
    public class WeatherForecastData
    {
        public ObjectId Id
        {
            get; set;
        }
        public int DT
        {
            get; set;
        }
        public float MainTemp
        {
            get; set;
        }
        public float MainFeelLike
        {
            get; set;
        }
        public float MainTempMin
        {
            get; set;
        }
        public float MainTempMax
        {
            get; set;
        }
        public int MainPressure
        {
            get; set;
        }
        public int MainSeaLevel
        {
            get; set;
        }
        public int MainGrandLevel
        {
            get; set;
        }
        public int MainHumidity
        {
            get; set;
        }
        public float MainTempKF
        {
            get; set;
        }
        public string WeatherId
        {
            get; set;
        }
        public string WeatherMain
        {
            get; set;
        }
        public string WeatherDescription
        {
            get; set;
        }
        public string WeatherIcon
        {
            get; set;
        }
        public int Clouds
        {
            get; set;
        }
        public string WindSpeed
        {
            get; set;
        }
        public string WindDeg
        {
            get; set;
        }
        public string WindGust
        {
            get; set;
        }
        public int Visibility
        {
            get; set;
        }
        public float Pop
        {
            get; set;
        }
        public string Pod
        {
            get; set;
        }
        public DateTime? DateTimeText
        {
            get; set;
        }
        public ObjectId CityID
        {
            get;
            set;
        }
    }
}
