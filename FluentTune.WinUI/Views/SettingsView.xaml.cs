using FluentTune.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml.Controls;

namespace FluentTune.WinUI.Views;

public sealed partial class SettingsView : Page
{
    readonly SettingsViewModel vm = Host.Provider.GetRequiredService<SettingsViewModel>();

    public SettingsView()
    {
        InitializeComponent();
    }
}