using Microsoft.AspNetCore.Mvc;

namespace Weather_Forecaster.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            return await Task.Run(() =>
                Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                })
            );
        }

        public string GetSummaryByTemperature(int temperatureCelsius)
        {
            return temperatureCelsius switch
            {
                < 0 => Summaries[0],      // Freezing
                < 6 => Summaries[1],      // Bracing
                < 11 => Summaries[2],     // Chilly
                < 16 => Summaries[3],     // Cool
                < 21 => Summaries[4],     // Mild
                < 26 => Summaries[5],     // Warm
                < 31 => Summaries[6],     // Balmy
                < 36 => Summaries[7],     // Hot
                < 41 => Summaries[8],     // Sweltering
                _ => Summaries[9]         // Scorching
            };
        }

        public string GetSummaryByTemperatureFahrenheit(int temperatureFahrenheit)
        {
            int temperatureCelsius = (int)((temperatureFahrenheit - 32) * 0.5556);
            return GetSummaryByTemperature(temperatureCelsius);
        }
    }
}
