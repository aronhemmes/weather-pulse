using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WeatherPulse.Models
{
    [Index(nameof(Phone), IsUnique = true)]
    public class RegisterUserRequest
    {
        [Required, Phone]
        public string Phone { get; set; }
        [Required]
        //[RegularExpression(@"^[a-zA-Z\\s]+(?:\\/[a-zA-Z\\s]+)?$", ErrorMessage = "Location is invalid")]
        public string Location { get; set; }
        [Required]
        public decimal Latitude { get; set; }
        [Required]
        public decimal Longitude { get; set; }
    }
}
