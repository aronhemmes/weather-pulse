using Microsoft.AspNetCore.Mvc;
using WeatherPulse.Services;

namespace WeatherPulse.Controllers
{
    [Route("")]
    [ApiController]
    public class MessageTestController : ControllerBase
    {
        private readonly IWeatherForecast weatherForecast;

        public MessageTestController(IWeatherForecast weatherForecast)
        {
            this.weatherForecast = weatherForecast;
        }

        [HttpGet("eindhoven")]
        public IActionResult GetWeather()
        {
            var result = weatherForecast.GetWeatherForecast("Eindhoven", (decimal)51.44, (decimal)5.48, "2023-06-03").Result;

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
