using Newtonsoft.Json;
using RestSharp;
using WeatherForecast.API.WeatherforecastRequest.V1.Modal;

namespace WeatherForecast.API.WeatherforecastRequest.V1.Services.WeatherForecastAPI
{
    public class WeatherForecastApiService : IWeatherForecastApiService
    {
        public DefaultResponse FetchWeatherData(string city, string endpoint, string appId)
        {
            var response = new DefaultResponse();

            var client = new RestClient(endpoint + "?q=" + city + "&appid=" + appId);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse r = client.Execute(request);
            response = JsonConvert.DeserializeObject<DefaultResponse>(r.Content);
            return response;
        }
    }
}
