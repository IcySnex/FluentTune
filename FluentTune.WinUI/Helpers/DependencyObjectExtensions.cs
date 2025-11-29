using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media;

namespace FluentTune.WinUI.Helpers;

public static class DependencyObjectExtensions
{
    extension(DependencyObject reference)
    {
        public T? FindChild<T>(
            string name) where T : FrameworkElement
        {
            int childCount = VisualTreeHelper.GetChildrenCount(reference);
            for (int i = 0; i < childCount; i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(reference, i);
                if (child is T element && element.Name == name)
                    return element;

                T? result = child.FindChild<T>(name);
                if (result is not null)
                    return result;
            }

            return null;
        }
    }
}