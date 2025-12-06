using CommunityToolkit.Mvvm.ComponentModel;

namespace FluentTune.ViewModels;

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    bool isPaneOpen = true;
}