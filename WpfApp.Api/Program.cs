var builder = WebApplication.CreateBuilder(args);

// --- 1. Register Services ---
builder.Services.AddEndpointsApiExplorer(); 

// THIS LINE IS NEW: It finds your TestController class
builder.Services.AddControllers(); 

builder.Services.AddOpenApiDocument(config =>
{
    config.PostProcess = document =>
    {
        document.Info.Title = "My API";
        document.Info.Version = "v1";
    };
});

var app = builder.Build();

// --- 2. Configure Middleware ---
if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();       
    app.UseSwaggerUi();     
}

app.UseHttpsRedirection();

// --- 3. Endpoints ---

// THIS LINE IS NEW: It maps the routes defined in your Controllers
app.MapControllers(); 

app.Run();