using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FluentTune.Services.Abstract;
using Microsoft.Extensions.Logging;

namespace FluentTune.ViewModels;

public partial class SettingsViewModel(
    ILogger<SettingsViewModel> logger,
    IThemeManager themeManager) : ObservableObject
{
    readonly ILogger<SettingsViewModel> logger = logger;
    readonly IThemeManager themeManager = themeManager;


    [RelayCommand]
    void ChangeTheme()
    {
        themeManager.ApplyTheme();
    }
}