using Microsoft.AspNetCore.Mvc;
using WeatherPulse.Models;
using WeatherPulse.Services;

namespace WeatherPulse.Controllers
{
    [Route("")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterUserRequest registerRequest)
        {
            var result = userService.Register(registerRequest).Result;

            if (result != null)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
