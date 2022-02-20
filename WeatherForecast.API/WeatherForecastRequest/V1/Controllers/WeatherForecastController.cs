using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WeatherForecast.API.WeatherforecastRequest.V1.Modal;
using WeatherForecast.API.WeatherforecastRequest.V1.Services.WeatherForecast;

namespace WeatherForecast.API.Controllers
{
    [ApiController]
    [Route("api/v1/WeatherForecast")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherForecastService weatherService;


        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastService weatherService)
        {
            _logger = logger;
            this.weatherService = weatherService;
        }

        [HttpGet]
        public WeatherDataResponse Get()
        {
            return weatherService.GetStoredWeatherData();
        }
    }
}
