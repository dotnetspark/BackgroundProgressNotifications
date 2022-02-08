using BackgroundProgressNotifications.Shared;
using Microsoft.AspNetCore.SignalR;

namespace BackgroundProgressNotifications.Server
{
    public class WeatherForecastService : BackgroundService
    {
        private readonly IHubContext<DopplerRadarHub, IDopplerRadar> _hubContext;
        private readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public WeatherForecastService(IHubContext<DopplerRadarHub, IDopplerRadar> hubContext)
        {
            this._hubContext = hubContext;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while(!stoppingToken.IsCancellationRequested)
            {
                await _hubContext.Clients.All.UpdateForecast(new WeatherForecast
                {
                    Date = DateTime.Now.AddMilliseconds(3000),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                });
                await Task.Delay(3000, stoppingToken);
            }
        }
    }
}
