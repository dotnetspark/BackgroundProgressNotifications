using BackgroundProgressNotifications.Shared;

namespace BackgroundProgressNotifications.Server
{
    public interface IWeatherRadarService
    {
        WeatherForecast GetForecast();
    }
}
