using System.Windows;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http; // Added for HttpClient
using System.Reflection;
using WpfApp1.Views; // Added for Scanning types

namespace WpfApp1;

public partial class App : Application
{
    public static IHost? AppHost { get; private set; }

    public App()
    {
        AppHost = Host.CreateDefaultBuilder()
            .ConfigureServices((hostContext, services) =>
            {
                // 1. Register the UI
                services.AddSingleton<MainWindow>();
                services.AddTransient<MainWindowViewModel>();
                
                services.AddSingleton<IDialogService, DialogService>();
                services.AddTransient<AddAssetViewModel>();

                // 2. AUTOMATIC API CLIENT REGISTRATION
                var apiBaseUrl = new Uri("http://localhost:5204");

                // Look through your project for NSwag generated classes
                var clientTypes = Assembly.GetExecutingAssembly()
                    .GetTypes()
                    .Where(t => t.IsClass && !t.IsAbstract && t.Name.EndsWith("Client"));
                
                services.AddHttpClient();

                foreach (var implementationType in clientTypes)
                {
                    // Find the interface (e.g., TestClient -> ITestClient)
                    var interfaceType = implementationType.GetInterface($"I{implementationType.Name}");

                    if (interfaceType != null)
                    {
                        // 1. Register the implementation (e.g., TestClient)
                        services.AddTransient(implementationType, sp =>
                        {
                            var httpClientFactory = sp.GetRequiredService<IHttpClientFactory>();
                            var httpClient = httpClientFactory.CreateClient();
                            httpClient.BaseAddress = apiBaseUrl;

                            // Create the client instance (e.g., new TestClient(httpClient))
                            return ActivatorUtilities.CreateInstance(sp, implementationType, httpClient);
                        });

                        // 2. Map the interface to that implementation
                        services.AddTransient(interfaceType, sp => sp.GetRequiredService(implementationType));
                    }
                }
            })
            .Build();
    }

    protected override async void OnStartup(StartupEventArgs e)
    {
        await AppHost!.StartAsync();
        var mainWindow = AppHost.Services.GetRequiredService<MainWindow>();
        mainWindow.Show();
        base.OnStartup(e);
    }

    protected override async void OnExit(ExitEventArgs e)
    {
        await AppHost!.StopAsync();
        base.OnExit(e);
    }
}