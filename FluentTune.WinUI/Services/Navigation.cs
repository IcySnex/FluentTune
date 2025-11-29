using FluentTune.Services.Abstract;
using FluentTune.WinUI.Helpers;
using FluentTune.WinUI.Views;
using Microsoft.Extensions.Logging;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Animation;

namespace FluentTune.WinUI.Services;

public class Navigation : INavigation
{
    readonly ILogger<Navigation> logger;

    readonly TitleBar titleBar;
    readonly NavigationView navigationView;
    readonly Frame frame;

    Button? backButton = null;
    Storyboard? backButtonInBoard = null;
    Storyboard? backButtonOutBoard = null;

    bool skipSelectionHandler = false;

    public Navigation(
        ILogger<Navigation> logger)
    {
        this.logger = logger;

        MainView mainView = ((MainView)WinUIHost.Window.Content);
        titleBar = mainView.TitleBar;
        navigationView = mainView.NavigationView;
        frame = mainView.Frame;

        titleBar.BackRequested += (s, e) =>
            GoBack();
        navigationView.SelectionChanged += (s, e) =>
        {
            if (skipSelectionHandler || e.SelectedItemContainer is null)
                return;

            SetPage(((string)e.SelectedItemContainer.Content).Replace(" ", ""));
        };
    }


    NavigationViewItem? GetItem(
        string key)
    {
        NavigationViewItem? item;

        item = (NavigationViewItem?)navigationView.MenuItems.FirstOrDefault(item =>
            item is NavigationViewItem navItem &&
            ((string)navItem.Content).Replace(" ", "") == key);
        item ??= (NavigationViewItem?)navigationView.FooterMenuItems.FirstOrDefault(item =>
            item is NavigationViewItem navItem &&
            ((string)navItem.Content).Replace(" ", "") == key);

        return item;
    }

    bool SetPage(
        string key)
    {
        logger.LogInformation("Setting page to '{key}'...", key);

        Type? type = Type.GetType($"FluentTune.WinUI.Views.{key}View, FluentTune.WinUI");
        if (type is null)
        {
            logger.LogError(new Exception($"Could not find page with type 'FluentTune.WinUI.Views.{key}View'."), "Failed to set page to 'FluentTune.WinUI.Views.{key}View'.", key);
            return false;
        }

        bool result = frame.Navigate(type);
        CanGoBackChanged();

        return result;
    }

    void CanGoBackChanged()
    {
        if (backButton is null && titleBar.FindChild<Button>("PART_BackButton") is Button button)
        {
            backButton = button;

            DoubleAnimation inAnim = new()
            {
                EnableDependentAnimation = true,
                To = 32,
                Duration = new(TimeSpan.FromMilliseconds(100))
            };
            backButtonInBoard = new()
            {
                Children = { inAnim }
            };
            Storyboard.SetTarget(inAnim, backButton);
            Storyboard.SetTargetProperty(inAnim, "Width");

            DoubleAnimation outAnim = new()
            {
                EnableDependentAnimation = true,
                To = 0,
                Duration = new(TimeSpan.FromMilliseconds(100))
            };
            backButtonOutBoard = new()
            {
                Children = { outAnim }
            };
            Storyboard.SetTarget(outAnim, backButton);
            Storyboard.SetTargetProperty(outAnim, "Width");
        }

        if (titleBar.IsBackButtonEnabled == CanGoBack)
            return;

        titleBar.IsBackButtonEnabled = CanGoBack;
        if (CanGoBack)
            backButtonInBoard?.Begin();
        else
            backButtonOutBoard?.Begin();
    }


    public bool Navigate(
        string key)
    {
        NavigationViewItem? item = GetItem(key);
        if (item is null)
        {
            logger.LogError(new Exception($"Could not find navigation item with key '{key}."), "Failed to navigate to '{key}'.", key);
            return false;
        }

        navigationView.SelectedItem = GetItem(key);
        return true;
    }


    public bool CanGoBack => frame.CanGoBack;

    public bool GoBack()
    {
        logger.LogInformation("Going back...");

        frame.GoBack();
        CanGoBackChanged();

        skipSelectionHandler = true;
        navigationView.SelectedItem = GetItem(frame.Content.GetType().Name.Replace("View", ""));
        skipSelectionHandler = false;

        return true;
    }
}