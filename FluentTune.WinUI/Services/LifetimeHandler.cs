using FluentTune.Services.Abstract;
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

        WinUIHost.Window.Closed += async (s, e) => await StopAsync();
        WinUIHost.Window.Activate();

        navigation.Navigate("Home");
    }

    public async Task StopAsync()
    {
        logger.LogInformation("Stopping application...");

        Environment.Exit(0);
    }
}