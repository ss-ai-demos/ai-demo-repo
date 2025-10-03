using Microsoft.Extensions.Logging;
using Moq;
using Weather_Forecaster.Controllers;

namespace Weather_Forecaster.Tests
{
    [TestClass]
    public class WeatherForecastControllerTests
    {
        private Mock<ILogger<WeatherForecastController>> _mockLogger = null!;
        private WeatherForecastController _controller = null!;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockLogger = new Mock<ILogger<WeatherForecastController>>();
            _controller = new WeatherForecastController(_mockLogger.Object);
        }

        [TestMethod]
        public async Task Get_ReturnsListOfWeatherForecasts()
        {
            var result = await _controller.Get();

            Assert.IsNotNull(result);
            var forecasts = result.ToList();
            Assert.AreEqual(5, forecasts.Count);
        }

        [TestMethod]
        public async Task Get_AllForecastsHaveFutureDates()
        {
            var result = await _controller.Get();

            var forecasts = result.ToList();
            var today = DateOnly.FromDateTime(DateTime.Now);

            foreach (var forecast in forecasts)
            {
                Assert.IsTrue(forecast.Date > today);
            }
        }

        [TestMethod]
        public async Task Get_AllForecastsHaveValidTemperature()
        {
            var result = await _controller.Get();

            var forecasts = result.ToList();

            foreach (var forecast in forecasts)
            {
                Assert.IsTrue(forecast.TemperatureC >= -20 && forecast.TemperatureC < 55);
            }
        }

        [TestMethod]
        public async Task Get_AllForecastsHaveSummary()
        {
            var result = await _controller.Get();

            var forecasts = result.ToList();

            foreach (var forecast in forecasts)
            {
                Assert.IsNotNull(forecast.Summary);
                Assert.IsFalse(string.IsNullOrWhiteSpace(forecast.Summary));
            }
        }

        [TestMethod]
        public void GetSummaryByTemperature_ReturnsFreezing_WhenTemperatureIsBelow0()
        {
            var result = _controller.GetSummaryByTemperature(-5);
            Assert.AreEqual("Freezing", result);
        }

        [TestMethod]
        public void GetSummaryByTemperature_ReturnsBracing_WhenTemperatureIsBetween0And5()
        {
            var result = _controller.GetSummaryByTemperature(3);
            Assert.AreEqual("Bracing", result);
        }

        [TestMethod]
        public void GetSummaryByTemperature_ReturnsChilly_WhenTemperatureIsBetween6And10()
        {
            var result = _controller.GetSummaryByTemperature(8);
            Assert.AreEqual("Chilly", result);
        }

        [TestMethod]
        public void GetSummaryByTemperature_ReturnsCool_WhenTemperatureIsBetween11And15()
        {
            var result = _controller.GetSummaryByTemperature(13);
            Assert.AreEqual("Cool", result);
        }

        [TestMethod]
        public void GetSummaryByTemperature_ReturnsMild_WhenTemperatureIsBetween16And20()
        {
            var result = _controller.GetSummaryByTemperature(18);
            Assert.AreEqual("Mild", result);
        }

        [TestMethod]
        public void GetSummaryByTemperature_ReturnsWarm_WhenTemperatureIsBetween21And25()
        {
            var result = _controller.GetSummaryByTemperature(23);
            Assert.AreEqual("Warm", result);
        }

        [TestMethod]
        public void GetSummaryByTemperature_ReturnsBalmy_WhenTemperatureIsBetween26And30()
        {
            var result = _controller.GetSummaryByTemperature(28);
            Assert.AreEqual("Balmy", result);
        }

        [TestMethod]
        public void GetSummaryByTemperature_ReturnsHot_WhenTemperatureIsBetween31And35()
        {
            var result = _controller.GetSummaryByTemperature(33);
            Assert.AreEqual("Hot", result);
        }

        [TestMethod]
        public void GetSummaryByTemperature_ReturnsSweltering_WhenTemperatureIsBetween36And40()
        {
            var result = _controller.GetSummaryByTemperature(38);
            Assert.AreEqual("Sweltering", result);
        }

        [TestMethod]
        public void GetSummaryByTemperature_ReturnsScorching_WhenTemperatureIs41OrHigher()
        {
            var result = _controller.GetSummaryByTemperature(45);
            Assert.AreEqual("Scorching", result);
        }

        [TestMethod]
        public void GetSummaryByTemperature_BoundaryTest_At0_ReturnsBracing()
        {
            var result = _controller.GetSummaryByTemperature(0);
            Assert.AreEqual("Bracing", result);
        }

        [TestMethod]
        public void GetSummaryByTemperature_BoundaryTest_At6_ReturnsChilly()
        {
            var result = _controller.GetSummaryByTemperature(6);
            Assert.AreEqual("Chilly", result);
        }

        [TestMethod]
        public void GetSummaryByTemperature_BoundaryTest_At11_ReturnsCool()
        {
            var result = _controller.GetSummaryByTemperature(11);
            Assert.AreEqual("Cool", result);
        }

        [TestMethod]
        public void GetSummaryByTemperatureFahrenheit_ReturnsCorrectSummary_For32F()
        {
            var result = _controller.GetSummaryByTemperatureFahrenheit(32);
            Assert.AreEqual("Bracing", result);
        }

        [TestMethod]
        public void GetSummaryByTemperatureFahrenheit_ReturnsCorrectSummary_For50F()
        {
            var result = _controller.GetSummaryByTemperatureFahrenheit(50);
            Assert.AreEqual("Chilly", result);
        }

        [TestMethod]
        public void GetSummaryByTemperatureFahrenheit_ReturnsCorrectSummary_For70F()
        {
            var result = _controller.GetSummaryByTemperatureFahrenheit(70);
            Assert.AreEqual("Warm", result);
        }

        [TestMethod]
        public void GetSummaryByTemperatureFahrenheit_ReturnsCorrectSummary_For90F()
        {
            var result = _controller.GetSummaryByTemperatureFahrenheit(90);
            Assert.AreEqual("Hot", result);
        }

        [TestMethod]
        public void GetSummaryByTemperatureFahrenheit_ReturnsCorrectSummary_For110F()
        {
            var result = _controller.GetSummaryByTemperatureFahrenheit(110);
            Assert.AreEqual("Scorching", result);
        }

        [TestMethod]
        public void GetSummaryByTemperatureFahrenheit_ReturnsCorrectSummary_For0F()
        {
            var result = _controller.GetSummaryByTemperatureFahrenheit(0);
            Assert.AreEqual("Freezing", result);
        }

        [TestMethod]
        public void GetSummaryByTemperatureFahrenheit_VerifiesConversionFormula()
        {
            int fahrenheit = 68;
            int expectedCelsius = (int)((fahrenheit - 32) * 0.5556);
            
            var result = _controller.GetSummaryByTemperatureFahrenheit(fahrenheit);
            var expectedResult = _controller.GetSummaryByTemperature(expectedCelsius);
            
            Assert.AreEqual(expectedResult, result);
        }
    }
}
