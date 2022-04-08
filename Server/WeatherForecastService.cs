using BackgroundProgressNotifications.Shared;
using Microsoft.AspNetCore.SignalR;

namespace BackgroundProgressNotifications.Server
{
    public class WeatherForecastService : BackgroundService
    {
        private readonly IHubContext<WeatherForecastServiceHub, IWeatherForecastServiceHub> _hubContext;
        private readonly IWeatherRadarService _weatherRadarService;

        public WeatherForecastService(IHubContext<WeatherForecastServiceHub, IWeatherForecastServiceHub> hubContext, IWeatherRadarService weatherRadarService) => (_hubContext, _weatherRadarService) = (hubContext, weatherRadarService);

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await _hubContext.Clients.All.UpdateForecast(_weatherRadarService.GetForecast());
                await Task.Delay(3000, stoppingToken);
            }
        }
    }
}
