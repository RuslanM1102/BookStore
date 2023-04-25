using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using BookStore.DatabaseModels;
using BookStore.Modules;

namespace BookStore.Pages.Auth
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
        }
        private void Login_TextChanged(object sender, TextChangedEventArgs e)
        {
            PlaceholderController.SetVisibility(Login.Text, LoginPlaceholder);
        }

        private void Password_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PlaceholderController.SetVisibility(Password.Password, PasswordPlaceholder);
        }

        private void Image_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
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

        private void AuthButton_Click(object sender, RoutedEventArgs e)
        {
            if (Login.Text.Length == 0)
            {
                MessageBox.Show("Логин не может быть пустым!");
                return;
            }

            BookStoreEntities context = BookStoreDB.GetContext();
            if (context.Accounts.Any(x => x.Login == Login.Text))
            {
                if (HashCoder.GetHashCode(Password.Password) == context.Accounts.Where(x => x.Login == Login.Text).First().Password)
                {
                    new MainMenu().Show();
                    Application.Current.MainWindow.Close();
                }
                else
                {
                    MessageBox.Show("Неправильный пароль");
                }
            }
            else
            {
                MessageBox.Show("Такого аккаунта не существует");
            }
        }

        private void ChangePasswordButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new PasswordPage());            
        }
    }
}
