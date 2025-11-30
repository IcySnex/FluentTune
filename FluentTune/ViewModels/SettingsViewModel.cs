using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.Logging;

namespace FluentTune.ViewModels;

public partial class SettingsViewModel(
    ILogger<SettingsViewModel> logger) : ObservableObject
{
    readonly ILogger<SettingsViewModel> logger = logger;

}