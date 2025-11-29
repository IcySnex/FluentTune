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
            ConfigureLogging(configuration, "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:l}{NewLine:l}{Exception:l}");

            Log.Logger = configuration.CreateLogger();

            builder.ClearProviders();
            builder.AddSerilog();
        });

        RegisterPlatformServices(services);
        RegisterServices(services);
        RegisterViewModels(services);

        Provider = services.BuildServiceProvider();
    }


    protected void RegisterServices(
        IServiceCollection services)
    { }

    protected void RegisterViewModels(
        IServiceCollection services)
    {
        services.AddSingleton<MainViewModel>();
    }


    protected virtual void ConfigureLogging(
        LoggerConfiguration configuration,
        string preferredTemplate)
    {
        configuration.MinimumLevel.Information();

        configuration.WriteTo.Debug(
            outputTemplate: preferredTemplate);
    }

    protected virtual void RegisterPlatformServices(
        IServiceCollection services)
    { }
}
