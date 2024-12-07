var builder = WebApplication.CreateBuilder(args);

// Singleton, immer dieselbe Instanz
//builder.Services.AddSingleton<StatsProvider>();

// selbst einen Scope erstellen
//builder.Services.AddScoped<StatsProvider>();

// jedes mal eine neue Instanz
//builder.Services.AddTransient<StatsProvider>();

builder.Services.AddSingleton<StatsProvider>();
builder.Services.AddSingleton<Ticker>();
builder.Services.AddHostedService(sp => sp.GetRequiredService<Ticker>());

foreach (var service in builder.Services)
{
    Console.WriteLine(service);
}

var app = builder.Build();

/*using (var scope = app.Services.CreateScope())
{
    var stats = scope.ServiceProvider.GetRequiredService<StatsProvider>();
    stats.Attack = 10;
    stats.Defense = 50;
}

app.MapGet("/", (StatsProvider stats, ILogger<Program> logger) =>
{
    stats.Attack += 1;
    stats.Defense += 1;
    //logger.LogWarning("Test");
    return new { stats.Attack, stats.Defense };
});*/

app.Run();


class StatsProvider
{
    public int Attack { get; set; }
    public int Defense { get; set; }
}

class Ticker(ILogger<Ticker> logger, StatsProvider stats, IServiceProvider sp) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        /*using (var scope = sp.CreateScope())
        {
            scope.ServiceProvider.GetRequiredService<Ticker>();
        }*/
        
        logger.LogInformation("test");
        while (true)
        {
            await Task.Delay(1000);
            stats.Attack++;
            stats.Defense++;
        }
    }
}
