using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BookStore.Modules
{
    internal class ThemeContoller
    {
        public static void SwitchTheme()
        {
            var genericTheme = new Uri("Styles/Dictionary.xaml", UriKind.Relative);
            var darkTheme = new Uri("Styles/DarkTheme.xaml", UriKind.Relative);
            var lightTheme = new Uri("Styles/LightTheme.xaml", UriKind.Relative);

            ResourceDictionary resourceDict = Application.Current.Resources;
            Uri newTheme = resourceDict.MergedDictionaries.Where(x => x.Source.OriginalString == lightTheme.OriginalString).Count() == 1 ? darkTheme : lightTheme;

            var mainDictionary = new ResourceDictionary() { Source = genericTheme };
            var colorDictionary = new ResourceDictionary() { Source = newTheme };

            resourceDict.MergedDictionaries.Clear();
            resourceDict.MergedDictionaries.Add(mainDictionary);
            resourceDict.MergedDictionaries.Add(colorDictionary);
        }
    }
}
