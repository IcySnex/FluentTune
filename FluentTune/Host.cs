using FluentTune.Helpers;
using FluentTune.Models;
using FluentTune.Services.Abstract;
using FluentTune.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;

namespace FluentTune;

public abstract class Host
{
    public static IServiceProvider Provider { get; private set; } = default!;

    protected Host()
    {
        IServiceCollection services = new ServiceCollection();

        services.AddLogging(builder =>
        {
            LoggerConfiguration configuration = new();
            ConfigureLogging(configuration, "[{Timestamp:HH:mm:ss} {Level:u3} {Class}] {Message:l}{NewLine:l}{Exception:l}");

            Log.Logger = configuration.CreateLogger();

            builder.ClearProviders();
            builder.AddSerilog();
        });

        RegisterPlatformServices(services);
        RegisterServices(services);
        RegisterViewModels(services);

        Provider = services.BuildServiceProvider();
    }


    protected static void RegisterServices(
        IServiceCollection services)
    {
        services.AddSingleton(provider =>
        {
            IPathResolver pathResolver = provider.GetRequiredService<IPathResolver>();

            if (!File.Exists(pathResolver.ConfigFilePath))
                return Config.Default;

            string json = File.ReadAllText(pathResolver.ConfigFilePath);
            return Json.Deserialize<Config>(json);
        });
    }

    protected static void RegisterViewModels(
        IServiceCollection services)
    {
        services.AddSingleton<MainViewModel>();
        services.AddSingleton<HomeViewModel>();
        services.AddSingleton<SettingsViewModel>();
    }


    protected virtual void ConfigureLogging(
        LoggerConfiguration configuration,
        string preferredTemplate)
    {
        configuration.MinimumLevel.Information();

        configuration.Enrich.With<SourceContextEnricher>();

        configuration.WriteTo.Debug(
            outputTemplate: preferredTemplate);
    }

    protected virtual void RegisterPlatformServices(
        IServiceCollection services)
    { }
}
