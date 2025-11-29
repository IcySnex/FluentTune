namespace FluentTune.Services.Abstract;

public interface INavigation
{
    bool Navigate(
        string key);


    bool CanGoBack { get; }

    bool GoBack();
}