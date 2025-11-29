using FluentTune.Services.Abstract;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;

namespace FluentTune.WinUI;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
    }


    protected override async void OnLaunched(
        LaunchActivatedEventArgs args)
    {
        WinUIHost _ = new();

        await Host.Provider.GetRequiredService<ILifetimeHandler>().StartAsync();
    }
}