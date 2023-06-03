using Microsoft.EntityFrameworkCore;
using WeatherPulse.Models;

namespace WeatherPulse.Data
{
    public class AuthDBContext : DbContext
    {
        public AuthDBContext(DbContextOptions<AuthDBContext> options) : base(options)
        {
        }

        public DbSet<User> User { get; set; } = default!;

    }
}
