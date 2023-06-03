using WeatherPulse.Models;

namespace WeatherPulse.Services
{
    public interface IUserService
    {
        Task<User?> Register(RegisterUserRequest registerRequest);

        Task<List<User>> GetAllUsers();
    }
}
