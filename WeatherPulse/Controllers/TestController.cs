using Microsoft.AspNetCore.Mvc;
using WeatherPulse.Models;
using WeatherPulse.Services;

namespace WeatherPulse.Controllers
{
    [Route("")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IMessager messager;
        private readonly IWeatherForecast weatherForecast;
        private readonly IUserService userService;

        public TestController(IMessager messager, IWeatherForecast weatherForecast, IUserService userService)
        {
            this.messager = messager;
            this.weatherForecast = weatherForecast;
            this.userService = userService;
        }


        [HttpGet("sendall")]
        public IActionResult SendMessages()
        {
            string currentDate = DateTime.Now.ToString("yyyy-MM-dd");

            List<User> users = userService.GetAllUsers().Result;

            List<Task> tasks = new();

            foreach (User user in users)
            {
                Task asyncTask = ProcessUserAsync(currentDate, user);
                tasks.Add(asyncTask);
            }

            return Ok();
        }
        private async Task ProcessUserAsync(string currentDate, User user)
        {
            string? message = await weatherForecast.GetWeatherForecast(user.Location, user.Latitude, user.Longitude, currentDate);

            if (message == null) return;

            await messager.SendMessage(message, user.Phone);
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
