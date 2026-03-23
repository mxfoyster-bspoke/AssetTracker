var builder = WebApplication.CreateBuilder(args);

// --- 1. Register Services ---
// This tells ASP.NET Core to allow other tools to "explore" your endpoints
builder.Services.AddEndpointsApiExplorer(); 

// This is your NSwag service
builder.Services.AddOpenApiDocument(config =>
{
    config.PostProcess = document =>
    {
        document.Info.Title = "Weather API";
        document.Info.Version = "v1";
    };
});

var app = builder.Build();

// --- 2. Configure Middleware ---
// Now that the app is built, we configure how it responds to requests
if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();       // Serves the actual JSON specification
    app.UseSwaggerUi();     // Serves the interactive UI at /swagger
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

// --- 3. Endpoints ---
app.MapGet("/weatherforecast", () =>
    {
        var forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
            .ToArray();
        return forecast;
    })
    .WithName("GetWeatherForecast");

app.Run();

// Data model for the API
record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
