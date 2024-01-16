using Microsoft.AspNetCore.Mvc;

namespace WeatherAPI.Controllers
{
    [ApiController]
   
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


        [HttpGet]
        [Route("GetWeatherForecast")]
        public IEnumerable<WeatherForecast> GetWeatherForecast()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
      

        [HttpPost]
        [Route("AddWeatherData")]
        public IActionResult AddWeatherData([FromBody] WeatherForecast data)
        {
            return StatusCode(200, "Weather added sucessfully");
        }
        [HttpGet]
       [ Route("Getdata")]
        public IActionResult GetData()
        {
            return StatusCode(200, "Response received from EA");
        }

    } 
   
}
