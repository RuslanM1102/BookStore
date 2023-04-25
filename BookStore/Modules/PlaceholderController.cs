using System.Windows;
using System.Windows.Controls;

namespace BookStore.Modules
{
    public class PlaceholderController
    {
        public static void SetVisibility(string text, Label placeholder)
        {
            placeholder.Visibility = text.Length > 0 ? Visibility.Hidden : Visibility.Visible;
        }
    }
}
