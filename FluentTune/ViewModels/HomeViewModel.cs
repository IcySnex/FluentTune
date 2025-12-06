using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FluentTune.Models;
using FluentTune.Types;
using Microsoft.Extensions.Logging;

namespace FluentTune.ViewModels;

public partial class HomeViewModel(
    ILogger<HomeViewModel> logger,
    Config config) : ObservableObject
{
    [RelayCommand]
    void ChangeTheme()
    {
        static string GetRandomColor(
            byte transparency = 255)
        {
            byte r = (byte)Random.Shared.Next(0, 256);
            byte g = (byte)Random.Shared.Next(0, 256);
            byte b = (byte)Random.Shared.Next(0, 256);

            return $"#{transparency:X2}{r:X2}{g:X2}{b:X2}";
        }


        logger.LogInformation("Randomizing theme...");

        Colors randomColors = new(
            accent: new(
                primary: GetRandomColor(),
                light1: GetRandomColor(),
                light2: GetRandomColor(),
                light3: GetRandomColor(),
                light4: GetRandomColor(),
                dark1: GetRandomColor(),
                dark2: GetRandomColor(),
                dark3: GetRandomColor(),
                dark4: GetRandomColor()),
            background: new(
                window: GetRandomColor(0),
                popup: GetRandomColor(),
                control: GetRandomColor(),
                controlLow: GetRandomColor(),
                controlMedium: GetRandomColor(),
                controlHigh: GetRandomColor(),
                statusNeutral: GetRandomColor(),
                statusSuccess: GetRandomColor(),
                statusCaution: GetRandomColor(),
                statusCritical: GetRandomColor()),
            stroke: new(
                popup: GetRandomColor(),
                control: GetRandomColor(),
                controlLow: GetRandomColor(),
                controlMedium: GetRandomColor(),
                controlHigh: GetRandomColor()),
            foreground: new(
                primary: GetRandomColor(),
                secondary: GetRandomColor(),
                tertiary: GetRandomColor(),
                quaternary: GetRandomColor(),
                onAccentPrimary: GetRandomColor(),
                onAccentSecondary: GetRandomColor(),
                onAccentTertiary: GetRandomColor(),
                onAccentQuaternary: GetRandomColor(),
                statusNeutral: GetRandomColor(),
                statusSuccess: GetRandomColor(),
                statusCaution: GetRandomColor(),
                statusCritical: GetRandomColor()));

        Colors.Override(config.Theme.Colors, randomColors);
    }

    [RelayCommand]
    void ChangeBackdrop()
    {
        config.Theme.Backdrop = config.Theme.Backdrop switch
        {
            BackdropEffect.None => BackdropEffect.Mica,
            BackdropEffect.Mica => BackdropEffect.MicaAlt,
            BackdropEffect.MicaAlt => BackdropEffect.Acrylic,
            BackdropEffect.Acrylic => BackdropEffect.None,
            _ => throw new()
        };
    }
}