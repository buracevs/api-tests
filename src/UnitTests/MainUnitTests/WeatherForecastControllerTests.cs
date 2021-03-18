using System.Linq;
using web_api.Controllers;
using Xunit;

namespace MainUnitTests
{
    public class WeatherForecastControllerTests
    {
        private readonly WeatherForecastController _weatherForecastControllerTests;

        public WeatherForecastControllerTests()
        {
            _weatherForecastControllerTests = new WeatherForecastController();
        }

        [Fact]
        public void Get_Returns_Correct_Data()
        {
            //Act
            var result = _weatherForecastControllerTests.Get();
            
            Assert.NotNull(result);
            var forecast = result.FirstOrDefault();
            Assert.NotNull(forecast);
            Assert.Equal("on", forecast.Summary);
            Assert.Equal(11, forecast.TemperatureC);
        }
    }
}