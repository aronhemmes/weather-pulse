using Microsoft.AspNetCore.Mvc;

namespace WeatherPulse.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
