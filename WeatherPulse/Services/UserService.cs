using Microsoft.EntityFrameworkCore;
using WeatherPulse.Data;
using WeatherPulse.Models;

namespace WeatherPulse.Services
{
    public class UserService : IUserService
    {
        private readonly UserDBContext userDBContext;

        public UserService(UserDBContext userDBContext)
        {
            this.userDBContext = userDBContext;
        }

        public async Task<User?> Register(RegisterUserRequest registerRequest)
        {
            User user = new()
            {
                Phone = registerRequest.Phone,
                Location = registerRequest.Location,
                Latitude = registerRequest.Latitude,
                Longitude = registerRequest.Longitude
            };

            try
            {
                var newuser = userDBContext.User.Add(user);
                await userDBContext.SaveChangesAsync();
                return newuser.Entity;

            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }

        public async Task<List<User>> GetAllUsers()
        {
            List<User> users = await userDBContext.User.ToListAsync();

            return users;
        }
    }
}
