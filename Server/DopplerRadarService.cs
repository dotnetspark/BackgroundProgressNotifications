using BackgroundProgressNotifications.Shared;
using Microsoft.AspNetCore.SignalR;

namespace BackgroundProgressNotifications.Server
{
    public class DopplerRadarService : IWeatherRadarService
    {
        private readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public WeatherForecast GetForecast() => new WeatherForecast
        {
            Date = DateTime.UtcNow.AddMilliseconds(3000),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        };
    }
}
