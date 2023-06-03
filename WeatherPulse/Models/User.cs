using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WeatherPulse.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Phone { get; set; }
        public string Location { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public string Timezone { get; set; }
    }
}
