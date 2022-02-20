using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherForecast.API.Controllers;
using WeatherForecast.API.WeatherforecastRequest.V1.Services.WeatherForecast;
using Xunit;

namespace WeatherForecast.Test
{
    [TestClass]
    public class WeatherForecastTestService
    {

        private readonly WeatherForecastController _controller;
        private readonly IWeatherForecastService _service;
        private readonly ILogger<WeatherForecastController> _logger;
        public WeatherForecastTestService()
        {
            _service = new WeatherForecastService();
            _controller = new WeatherForecastController();
        }

        [Fact]
        public void IsApiReturnsData()
        {
            var weatherController = new WeatherForecastController();
            var result = weatherController.Get();
            //Assert
            Assert.AreEqual(200, result.StatusCode);
        }
        [Fact]
        public void TestServiceToFetchWeather()
        {
            var weatherController = new WeatherForecastController();
            var res = _service.GetWeatherForecastData();
            Assert.Equals("Sucessfully Updated!", res);
        }
    }
}
