using CommunityToolkit.Mvvm.ComponentModel;
using FluentTune.Helpers;
using FluentTune.Types;

namespace FluentTune.Models;

public class Config(
    Theme theme)
{
    public static Config Default => new(
        theme: new(
            mode: ThemeMode.System,
            useSystemAccent: true,
            backdrop: BackdropEffect.Mica,
            colors: Colors.Dark));


    public Theme Theme { get; } = theme;
}