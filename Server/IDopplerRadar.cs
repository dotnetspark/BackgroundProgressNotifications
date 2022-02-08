using BackgroundProgressNotifications.Shared;

namespace BackgroundProgressNotifications.Server
{
    public interface IDopplerRadar
    {
        Task UpdateForecast(WeatherForecast forecast);
    }
}
