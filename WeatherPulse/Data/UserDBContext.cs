using Microsoft.EntityFrameworkCore;
using WeatherPulse.Models;

namespace WeatherPulse.Data
{
    public class UserDBContext : DbContext
    {
        public UserDBContext(DbContextOptions<UserDBContext> options) : base(options)
        {
        }

        public DbSet<User> User { get; set; } = default!;

    }
}
