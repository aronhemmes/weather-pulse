using CM.Text;
using System;

namespace WeatherPulse.Services
{
    public class Messager : IMessager
    {
        public async Task<TextClientResult> SendMessage(string message, string phone)
        {
            //var client = new TextClient(new Guid(ConfigurationManager.AppSettings["ApiKey"]));

            //var result = await client.SendMessageAsync(message, "Weather Pulse", new List<string> { phone }, "Your_Reference").ConfigureAwait(false);

            throw new NotImplementedException();
            //return result;
        }
    }
}
