using Microsoft.AspNetCore.Mvc;

namespace _01_WebApiGiris.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]//Action seviyesinde
    //[Route("[controller]")]//Controller seviyesinde
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
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
        [HttpGet]
        public string HavaDurumu(string name)
        {
            return $"Hoşgeldin {name} bugün hava yazdan kalma {Random.Shared.Next(10, 20)} derece";
        }
        [HttpGet]
        public string GetHavaDurumu(int val)
        {
            return $"Bugün hava {val} derece";
        }
        [HttpPost]
        public string PostHavaDurumu(int val)
        {
            return $"Gelen hava durumu bilgisi {val} derece";
        }
    }
}