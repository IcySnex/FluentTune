using FluentTune.Services.Abstract;
using FluentTune.WinUI.Services;
using FluentTune.WinUI.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media;
using Serilog;

namespace FluentTune.WinUI;

internal class WinUIHost : Host
{
    public static Window Window { get; private set; } = default!;

    public WinUIHost() : base()
    {
        MainView content = new();

        Window = new()
        {
            Title = "FluentTune",
            SystemBackdrop = new MicaBackdrop(),
            Content = content,
        };

        Window.SetTitleBar(content.TitleBar);
        Window.ExtendsContentIntoTitleBar = true;
        Window.AppWindow.TitleBar.PreferredHeightOption = TitleBarHeightOption.Tall;

        OverlappedPresenter presenter = OverlappedPresenter.Create();
        presenter.PreferredMinimumWidth = 800;
        presenter.PreferredMinimumHeight = 500;
        Window.AppWindow.SetPresenter(presenter);

        Window.AppWindow.Resize(new(1100, 600));

        Window.AppWindow.SetIcon("Assets/Icon.ico");
    }


    readonly PathResolver pathResolver = new();


    protected override void ConfigureLogging(
        LoggerConfiguration configuration,
        string preferredTemplate)
    {
        base.ConfigureLogging(configuration, preferredTemplate);

        configuration.WriteTo.File(
            path: pathResolver.LogFilepath,
            rollingInterval: RollingInterval.Day,
            retainedFileCountLimit: 10,
            outputTemplate: preferredTemplate);
    }

    protected override void RegisterPlatformServices(
        IServiceCollection services)
    {
        services.AddSingleton<ILifetimeHandler, LifetimeHandler>();
        services.AddSingleton<INavigation, Navigation>();

        services.AddSingleton<IPathResolver>(pathResolver);
    }
}
