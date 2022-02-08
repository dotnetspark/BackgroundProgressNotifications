using BackgroundProgressNotifications.Shared;
using Microsoft.AspNetCore.SignalR;

namespace BackgroundProgressNotifications.Server
{
    public class DopplerRadarHub: Hub<IDopplerRadar>
    {
        public async Task ReportProgress(WeatherForecast forecast) => await Clients.All.UpdateForecast(forecast);
    }
}
