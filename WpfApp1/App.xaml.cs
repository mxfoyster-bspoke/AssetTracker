using System.Windows;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace WpfApp1;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public static IHost? AppHost { get; private set; }

    public App()
    {
        AppHost = Host.CreateDefaultBuilder()
            .ConfigureServices((hostContext, services) =>
            {
                // 1. Register the Main Window
                services.AddSingleton<MainWindow>();
                
                // Register the ViewModel <-- IS THIS LINE PRESENT?
                services.AddTransient<MainWindowViewModel>();

                // 2. Register the HttpClient and your Generated Client
                // This handles connection pooling for you! 
                services.AddHttpClient<IApiClient, ApiClient>(client =>
                {
                    client.BaseAddress = new Uri("https://localhost:7001");
                });
            })
            .Build();
    }

    protected override async void OnStartup(StartupEventArgs e)
    {
        await AppHost!.StartAsync();

        // Start the MainWindow through DI
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