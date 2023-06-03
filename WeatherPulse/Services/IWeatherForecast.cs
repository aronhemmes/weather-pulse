using WeatherPulse.Models;

namespace WeatherPulse.Services
{
    public interface IWeatherForecast
    {
        Task<string?> GetWeatherForecast(string location, float latitude, float longitude, string day);
    }
}
