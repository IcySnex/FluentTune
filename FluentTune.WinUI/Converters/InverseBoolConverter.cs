using Microsoft.UI.Xaml.Data;

namespace FluentTune.WinUI.Converters;

internal partial class InverseBoolConverter : IValueConverter
{
    public object Convert(
        object value,
        Type targetType,
        object parameter,
        string language) =>
        !(bool)value;

    public object ConvertBack(
        object value,
        Type targetType,
        object parameter,
        string language) =>
        !(bool)value;
}