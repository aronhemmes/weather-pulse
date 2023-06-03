using CM.Text;
using System;

namespace WeatherPulse.Services
{
    public class Messager : IMessager
    {
        private readonly IConfiguration configuration;

        public Messager(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<TextClientResult?> SendMessage(string message, string phone)
        {
            string? key = configuration.GetSection("ApiKey").Value;
            if (key == null) return null;

            var client = new TextClient(new Guid(key));

            var result = await client.SendMessageAsync(message, "Weather Pulse", new List<string> { phone }, "Your_Reference").ConfigureAwait(false);

            return result;
        }
    }
}
