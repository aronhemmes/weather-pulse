using WeatherPulse.Models;

namespace WeatherPulse.Services
{
    public class DailySchedulerService : IHostedService, IDisposable
    {
        private Timer? timer;
        private readonly IMessager messager;
        private readonly IWeatherForecast weatherForecast;
        private readonly IUserService userService;

        public DailySchedulerService(IMessager messager, IWeatherForecast weatherForecast, IUserService userService)
        {
            this.messager = messager;
            this.weatherForecast = weatherForecast;
            this.userService = userService;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            var now = DateTime.Now;
            var desiredTime = new DateTime(now.Year, now.Month, now.Day, 9, 0, 0); // 9:00 AM
            TimeSpan delay = desiredTime - now;
            if (delay < TimeSpan.Zero)
            {
                delay = TimeSpan.FromDays(1) + delay;
            }

            timer = new Timer(SendMessages, null, delay, TimeSpan.FromDays(1));

            return Task.CompletedTask;
        }

        private void SendMessages(object state)
        {
            string currentDate = DateTime.Now.ToString("yyyy-MM-dd");

            List<User> users = userService.GetAllUsers().Result;

            List<Task> tasks = new();

            foreach (User user in users)
            {
                Task asyncTask = ProcessUserAsync(currentDate, user);
                tasks.Add(asyncTask);
            }
        }
        private async Task ProcessUserAsync(string currentDate, User user)
        {
            string? message = await weatherForecast.GetWeatherForecast(user.Location, user.Latitude, user.Longitude, currentDate);

            if (message == null) return;

            await messager.SendMessage(message, user.Phone);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            // Stop and dispose of the timer when the application is stopped
            timer?.Change(Timeout.Infinite, 0);
            timer?.Dispose();
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            timer?.Dispose();
        }

    }
}
