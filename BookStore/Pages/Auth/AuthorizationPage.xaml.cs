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
            new MainMenu().Show();
            MainWindow.Instance.Close();
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
            ThemeController.SwitchTheme();
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
                var passwordHash = context.Accounts.Where(x => x.Login == Login.Text).First().Password;
                if (Password.Password == (passwordHash ?? "") || HashCoder.GetHashCode(Password.Password) == passwordHash)
                {
                    new MainMenu().Show();
                    MainWindow.Instance.Close();
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
