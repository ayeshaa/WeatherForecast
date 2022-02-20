using MongoDB.Bson;

namespace WeatherForecast.Data.Entities.City
{
    public class City
    {
        public ObjectId Id
        {
            get; set;
        }
        public string Name
        {
            get; set;
        }
        public float Latitude
        {
            get; set;
        }
        public float Longitude
        {
            get; set;
        }
        public string Country
        {
            get; set;
        }
        public int Population
        {
            get; set;
        }
        public int TimeZone
        {
            get; set;
        }
        public int Sunrise
        {
            get; set;
        }
        public int Sunset
        {
            get; set;
        }
    }
}
