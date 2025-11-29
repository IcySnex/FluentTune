namespace FluentTune.Services.Abstract;

public interface ILifetimeHandler
{
    Task StartAsync();

    Task StopAsync();
}