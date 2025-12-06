using FluentTune.Helpers;
using FluentTune.Models;
using FluentTune.Services.Abstract;
using Microsoft.Extensions.Logging;
using Microsoft.UI.Xaml;

namespace FluentTune.WinUI.Services;

public class LifetimeHandler(
    ILogger<LifetimeHandler> logger,
    Config config,
    IPathResolver pathResolver,
    INavigation navigation,
    IThemeManager themeManager) : ILifetimeHandler
{
    readonly ILogger<LifetimeHandler> logger = logger;
    readonly Config config = config;
    readonly IPathResolver pathResolver = pathResolver;
    readonly INavigation navigation = navigation;
    readonly IThemeManager themeManager = themeManager;


    public async Task StartAsync()
    {
        logger.LogInformation("Starting application...");

        // Theme
        themeManager.Initialize();

        // Window
        ((FrameworkElement)WinUIHost.Window.Content).Loaded += (s, e) => navigation.Navigate("Home");
        WinUIHost.Window.Closed += async (s, e) => await StopAsync();

        WinUIHost.Window.Activate();
    }

    public async Task StopAsync()
    {
        logger.LogInformation("Stopping application...");

        // Save Config
        string directoryPath = Path.GetDirectoryName(pathResolver.ConfigFilePath) ?? string.Empty;
        Directory.CreateDirectory(directoryPath);

        string json = Json.Serialize(config, true);
        await File.WriteAllTextAsync(pathResolver.ConfigFilePath, json);

        Environment.Exit(0);
    }
}