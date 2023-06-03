using System.Globalization;
using System.Text.Json;

namespace WeatherPulse.Services
{
    public class WeatherForecast : IWeatherForecast
    {
        public async Task<string?> GetWeatherForecast(string location, decimal latitude, decimal longitude, string day)
        {
            string lat = latitude.ToString(CultureInfo.InvariantCulture);
            string lon = longitude.ToString(CultureInfo.InvariantCulture);
            string url = $"https://api.open-meteo.com/v1/forecast?latitude={lat}&longitude={lon}&current_weather=true&hourly=temperature_2m,precipitation&timezone=auto&start_date={day}&end_date={day}";

            using HttpClient client = new();

            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();

            JsonDocument document = JsonDocument.Parse(responseBody);
            JsonElement hourly = document.RootElement.GetProperty("hourly");
            JsonElement precipitation = hourly.GetProperty("precipitation");
            JsonElement temperature_2m = hourly.GetProperty("temperature_2m");
            List<decimal> precipitationList = JsonSerializer.Deserialize<List<decimal>>(precipitation.GetRawText());
            List<decimal> temperatureList = JsonSerializer.Deserialize<List<decimal>>(temperature_2m.GetRawText());


            return ForecastMessage(location, temperatureList.Min(), temperatureList.Max(), precipitationList.Max());
        }

        private static string ForecastMessage(string location, decimal tempLow, decimal tempHigh, decimal precipitation)
        {
            string message = $"Good morning!\n\nToday's weather forecast at {location}:\n- Temperature: {tempLow}°C - {tempHigh}°C\n- Precipitation: {precipitation} mm";

            if (message.Length > 160)
                message = string.Concat(message.AsSpan(0, 157), "...");

            return message;
        }
    }
}
