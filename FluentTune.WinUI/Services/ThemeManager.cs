using FluentTune.Helpers;
using FluentTune.Models;
using FluentTune.Services.Abstract;
using FluentTune.Types;
using FluentTune.WinUI.Helpers;
using Microsoft.Extensions.Logging;
using Microsoft.UI.Composition.SystemBackdrops;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media;
using System.ComponentModel;
using Windows.UI;

namespace FluentTune.WinUI.Services;

public class ThemeManager(
    ILogger<ThemeManager> logger,
    Config config) : IThemeManager
{
    void OnThemePropertyChanged(
        object? sender,
        PropertyChangedEventArgs e)
    {
        switch (e.PropertyName)
        {
            case nameof(Theme.Backdrop):
                ApplyBackdrop(config.Theme.Backdrop);
                break;
        }
    }

    void OnThemeColorsBackgroundPropertyChanged(
        object? sender,
        PropertyChangedEventArgs e)
    {
        switch (e.PropertyName)
        {
            case nameof(Theme.Colors.Background.Control):
                WinUIHost.Window.AppWindow.TitleBar.ButtonHoverBackgroundColor = config.Theme.Colors.Background.Control.ToColor();
                break;
            case nameof(Theme.Colors.Background.ControlLow):
                WinUIHost.Window.AppWindow.TitleBar.ButtonPressedBackgroundColor = config.Theme.Colors.Background.ControlLow.ToColor();
                break;
        }
    }

    void OnThemeColorsForegroundPropertyChanged(
        object? sender,
        PropertyChangedEventArgs e)
    {
        switch (e.PropertyName)
        {
            case nameof(Theme.Colors.Foreground.Primary):
                WinUIHost.Window.AppWindow.TitleBar.ButtonForegroundColor = config.Theme.Colors.Foreground.Primary.ToColor();
                break;
            case nameof(Theme.Colors.Foreground.Secondary):
                WinUIHost.Window.AppWindow.TitleBar.ButtonInactiveForegroundColor = config.Theme.Colors.Foreground.Secondary.ToColor();
                break;
            case nameof(Theme.Colors.Foreground.Tertiary):
                WinUIHost.Window.AppWindow.TitleBar.ButtonInactiveForegroundColor = config.Theme.Colors.Foreground.Tertiary.ToColor();
                break;
            case nameof(Theme.Colors.Foreground.Quaternary):
                WinUIHost.Window.AppWindow.TitleBar.ButtonInactiveForegroundColor = config.Theme.Colors.Foreground.Quaternary.ToColor();
                break;
        }
    }


    void ApplyBackdrop(
        BackdropEffect backdrop)
    {
        logger.LogInformation("Applying backdrop...");

        switch (backdrop)
        {
            case BackdropEffect.None:
                if (WinUIHost.Window.SystemBackdrop is not null)
                    WinUIHost.Window.SystemBackdrop = null;
                break;
            case BackdropEffect.Mica:
                if (WinUIHost.Window.SystemBackdrop is not MicaBackdrop mica || mica.Kind != MicaKind.Base)
                    WinUIHost.Window.SystemBackdrop = new MicaBackdrop() { Kind = MicaKind.Base };
                break;
            case BackdropEffect.MicaAlt:
                if (WinUIHost.Window.SystemBackdrop is not MicaBackdrop micaAlt || micaAlt.Kind != MicaKind.BaseAlt)
                    WinUIHost.Window.SystemBackdrop = new MicaBackdrop() { Kind = MicaKind.BaseAlt };
                break;
            case BackdropEffect.Acrylic:
                if (WinUIHost.Window.SystemBackdrop is not DesktopAcrylicBackdrop)
                    WinUIHost.Window.SystemBackdrop = new DesktopAcrylicBackdrop();
                break;
        }
    }


    public void Initialize()
    {
        logger.LogInformation("Initializing theme...");

        // Sync UI colors & config 
        Colors appColors = (Colors)Application.Current.Resources["Colors"];

        Colors.Override(appColors, config.Theme.Colors);
        config.Theme.Colors.Accent = appColors.Accent;
        config.Theme.Colors.Background = appColors.Background;
        config.Theme.Colors.Stroke = appColors.Stroke;
        config.Theme.Colors.Foreground = appColors.Foreground;

        // Titlebar colors
        WinUIHost.Window.AppWindow.TitleBar.ButtonBackgroundColor = Color.FromArgb(0, 0, 0, 0);
        WinUIHost.Window.AppWindow.TitleBar.ButtonInactiveBackgroundColor = Color.FromArgb(0, 0, 0, 0);
        WinUIHost.Window.AppWindow.TitleBar.ButtonHoverBackgroundColor = config.Theme.Colors.Background.Control.ToColor();
        WinUIHost.Window.AppWindow.TitleBar.ButtonPressedBackgroundColor = config.Theme.Colors.Background.ControlLow.ToColor();

        WinUIHost.Window.AppWindow.TitleBar.ButtonForegroundColor = config.Theme.Colors.Foreground.Primary.ToColor();
        WinUIHost.Window.AppWindow.TitleBar.ButtonInactiveForegroundColor = config.Theme.Colors.Foreground.Quaternary.ToColor();
        WinUIHost.Window.AppWindow.TitleBar.ButtonHoverForegroundColor = config.Theme.Colors.Foreground.Secondary.ToColor();
        WinUIHost.Window.AppWindow.TitleBar.ButtonPressedForegroundColor = config.Theme.Colors.Foreground.Tertiary.ToColor();

        // Backdrop
        ApplyBackdrop(config.Theme.Backdrop);

        // Handlers
        config.Theme.PropertyChanged += OnThemePropertyChanged;
        config.Theme.Colors.Background.PropertyChanged += OnThemeColorsBackgroundPropertyChanged;
        config.Theme.Colors.Foreground.PropertyChanged += OnThemeColorsForegroundPropertyChanged;

    }
}