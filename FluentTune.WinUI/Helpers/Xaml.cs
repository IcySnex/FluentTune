namespace FluentTune.WinUI.Helpers;

public static class Xaml
{
    public static bool Inverse(
        bool value) =>
        !value;

    public static bool IsNot(
        object source,
        object target) =>
        !source.Equals(target);
}