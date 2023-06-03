using WeatherPulse.Models;

namespace WeatherPulse.Services
{
    public interface IWeatherForecast
    {
        Task<string?> GetWeatherForecast(string location, decimal latitude, decimal longitude, string day);
    }
}
