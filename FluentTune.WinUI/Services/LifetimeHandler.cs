using FluentTune.Services.Abstract;
using FluentTune.WinUI.Views;
using Microsoft.Extensions.Logging;
using Microsoft.UI.Xaml;

namespace FluentTune.WinUI.Services;

public class LifetimeHandler(
    ILogger<LifetimeHandler> logger,
    INavigation navigation) : ILifetimeHandler
{
    readonly ILogger<LifetimeHandler> logger = logger;
    readonly INavigation navigation = navigation;


    public Window Window { get; private set; } = default!;


    public async Task StartAsync()
    {
        logger.LogInformation("Starting application...");

        ((MainView)WinUIHost.Window.Content).Loaded += (s, e) =>
        {
            navigation.Navigate("Home");
        };
        WinUIHost.Window.Closed += async (s, e) => await StopAsync();

        WinUIHost.Window.Activate();
    }

    public async Task StopAsync()
    {
        logger.LogInformation("Stopping application...");

        Environment.Exit(0);
    }
}