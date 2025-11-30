using FluentTune.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml.Controls;

namespace FluentTune.WinUI.Views;

public sealed partial class HomeView : Page
{
    readonly HomeViewModel vm = Host.Provider.GetRequiredService<HomeViewModel>();

    public HomeView()
    {
        InitializeComponent();
    }
}