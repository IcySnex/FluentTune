using FluentTune.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml.Controls;

namespace FluentTune.WinUI.Views;

public sealed partial class MainView : UserControl
{
    readonly MainViewModel vm = Host.Provider.GetRequiredService<MainViewModel>();

    public MainView()
    {
        InitializeComponent();
    }
}
