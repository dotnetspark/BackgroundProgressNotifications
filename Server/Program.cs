using BackgroundProgressNotifications.Server;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddHostedService<WeatherForecastService>();
builder.Services.AddSingleton<IWeatherRadarService, DopplerRadarService>();
builder.Services.AddSignalR(options => options.EnableDetailedErrors = true)
    .AddMessagePackProtocol();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<WeatherForecastServiceHub>("/weather");
});
app.MapFallbackToFile("index.html");

app.Run();
