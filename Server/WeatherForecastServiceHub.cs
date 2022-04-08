using Microsoft.AspNetCore.SignalR;

namespace BackgroundProgressNotifications.Server
{
    public class WeatherForecastServiceHub : Hub<IWeatherForecastServiceHub>
    {
        private readonly ILogger<WeatherForecastServiceHub> _logger;

        public WeatherForecastServiceHub(ILogger<WeatherForecastServiceHub> logger) => _logger = logger;

        public override async Task OnConnectedAsync() => await Task.Run(() => _logger.LogInformation("Client connected"));

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            if (exception != null)
            {
                await Task.Run(() => _logger.LogInformation("Client disconnected"));
            }
            else
            {
                await Task.Run(() => _logger.LogError("An error has occured", exception));
            }
        }
    }
}
