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
        }

        [Fact]
        public void IsApiReturnsData()
        {
            var result = _service.GetStoredWeatherData();
            //Assert
            Assert.AreEqual(200, result.StatusCode);
        }
        [Fact]
        public void TestServiceToFetchWeather()
        {
            var res = _service.GetWeatherForecastData();
            Assert.Equals("Sucessfully Updated!", res);
        }
    }
}


