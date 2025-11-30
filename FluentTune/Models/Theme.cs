using CommunityToolkit.Mvvm.ComponentModel;
using FluentTune.Types;

namespace FluentTune.Models;

public partial class Theme(
    ThemeMode mode,
    bool useSystemAccent,
    BackdropEffect backdrop,
    Colors colors) : ObservableObject
{
    [ObservableProperty]
    ThemeMode mode = mode;

    [ObservableProperty]
    bool useSystemAccent = useSystemAccent;

    [ObservableProperty]
    BackdropEffect backdrop = backdrop;

    public Colors Colors { get; } = colors;
}