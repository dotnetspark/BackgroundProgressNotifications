using BackgroundProgressNotifications.Shared;

namespace BackgroundProgressNotifications.Server
{
    public interface IWeatherForecastServiceHub
    {
        Task UpdateForecast(WeatherForecast forecast);
    }
}
