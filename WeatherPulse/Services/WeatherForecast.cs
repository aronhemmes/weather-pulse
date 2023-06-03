using System.Text.Json;
using WeatherPulse.Models;

namespace WeatherPulse.Services
{
    public class WeatherForecast : IWeatherForecast
    {
        public async Task<string?> GetWeatherForecast(string location, float latitude, float longitude, string day)
        {
            string url = $"https://api.open-meteo.com/v1/forecast?latitude={latitude}&longitude={longitude}&current_weather=true&hourly=temperature_2m,precipitation&timezone=auto&start_date={day}&end_date={day}";

            using HttpClient client = new();

            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseBody);

                var json = JsonDocument.Parse(responseBody);
                decimal[] temperature = json.RootElement.GetProperty("hourly").GetProperty("temperature_2m").EnumerateArray().Select(x => x.GetDecimal()).ToArray();
                decimal[] precipitation = json.RootElement.GetProperty("hourly").GetProperty("precipitation").EnumerateArray().Select(x => x.GetDecimal()).ToArray();


                return ForecastMessage(location, temperature.Min(), temperature.Max(), precipitation.Max());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }

        private string ForecastMessage(string location, decimal tempLow, decimal tempHigh, decimal precipitation)
        {
            string message = $"Good morning!\n\nToday's weather forecast at {location}:\n- Temperature: {tempLow}°C - {tempHigh}°C\n- Precipitation: {precipitation} mm";

            if (message.Length > 160)
                message = string.Concat(message.AsSpan(0, 157), "...");

            return message;
        }
    }
}
