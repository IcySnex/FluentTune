using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.Logging;

namespace FluentTune.ViewModels;

public partial class MainViewModel(
    ILogger<MainViewModel> logger) : ObservableObject
{
    readonly ILogger<MainViewModel> logger = logger;


    [ObservableProperty]
    bool isPaneOpen = true;
}