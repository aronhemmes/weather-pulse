using CM.Text;

namespace WeatherPulse.Services
{
    public interface IMessager
    {
        Task<TextClientResult?> SendMessage(string message, string phone);
    }
}
