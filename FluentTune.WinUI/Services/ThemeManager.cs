using FluentTune.Models;
using FluentTune.Services.Abstract;
using Microsoft.Extensions.Logging;
using Microsoft.UI.Xaml;

namespace FluentTune.WinUI.Services;

public class ThemeManager(
    ILogger<ThemeManager> logger) : IThemeManager
{
    readonly ILogger<ThemeManager> logger = logger;


    readonly Theme theme = new();

    public void ApplyTheme()
    {
        logger.LogInformation("Applying theme...");

        ResourceDictionary resources = Application.Current.Resources;

        resources["SystemAccentColor"] = theme.Accent;
        resources["SystemAccentColorLight1"] = theme.AccentLight1;
        resources["SystemAccentColorLight2"] = theme.AccentLight2;
        resources["SystemAccentColorLight3"] = theme.AccentLight3;
        resources["SystemAccentColorDark1"] = theme.AccentDark1;
        resources["SystemAccentColorDark2"] = theme.AccentDark2;
        resources["SystemAccentColorDark3"] = theme.AccentDark3;
    }
}