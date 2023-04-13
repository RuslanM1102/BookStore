using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using System.Linq;

namespace BookStore
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new DateTimeViewModel();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            e.Cancel = MessageBox.Show(this, "Вы уверены?", "Выход",
                MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes) == MessageBoxResult.No;
        }

        private void Login_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            LoginPlaceholder.Visibility = Login.Text.Length > 0 ? Visibility.Hidden : Visibility.Visible;
        }

        private void Password_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordPlaceholder.Visibility = Password.Password.Length > 0 ? Visibility.Hidden : Visibility.Visible;
        }

        private void Image_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var darkTheme = new Uri("Styles/DarkTheme.xaml", UriKind.Relative);
            var lightTheme = new Uri("Styles/LightTheme.xaml", UriKind.Relative);

            ResourceDictionary resourceDict = Application.LoadComponent(new Uri("Styles/Dictionary.xaml", UriKind.Relative)) as ResourceDictionary;
            PasswordPlaceholder.Content = resourceDict.MergedDictionaries[0].Source.OriginalString;
            Uri newTheme = resourceDict.MergedDictionaries.Where(x => x.Source.OriginalString == lightTheme.OriginalString).Count() == 1 ? darkTheme : lightTheme;

            resourceDict.MergedDictionaries.Clear();
            resourceDict.MergedDictionaries.Add(Application.LoadComponent(newTheme) as ResourceDictionary);

            LoginPlaceholder.Content = newTheme.OriginalString;
        }
    }
}
