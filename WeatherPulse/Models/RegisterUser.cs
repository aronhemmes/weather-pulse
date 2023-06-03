using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WeatherPulse.Models
{
    [Index(nameof(Phone), IsUnique = true)]
    public class RegisterUser
    {
        [Required, Phone]
        public string Phone { get; set; }
        [Required]
        //[RegularExpression("YourRegularExpressionPattern", ErrorMessage = "Invalid location format")]
        public string Location { get; set; }
    }
}
