using Microsoft.UI.Xaml.Data;
using Windows.UI;

namespace FluentTune.WinUI.Helpers;

public partial class HexStringToColorConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        string hex = (string)value;
        return hex.ToColor();
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        Color color = (Color)value;
        return $"{color.A:X2}{color.R:X2}{color.G:X2}{color.B:X2}";
    }
}