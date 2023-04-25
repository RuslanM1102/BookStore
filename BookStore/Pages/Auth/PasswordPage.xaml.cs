using BookStore.DatabaseModels;
using BookStore.Modules;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace BookStore.Pages.Auth
{
    /// <summary>
    /// Логика взаимодействия для PasswordPage.xaml
    /// </summary>
    public partial class PasswordPage : Page
    {
        public PasswordPage()
        {
            InitializeComponent();
        }
        private void Login_TextChanged(object sender, TextChangedEventArgs e)
        {
            PlaceholderController.SetVisibility(Login.Text, LoginPlaceholder);
        }

        private void OldPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PlaceholderController.SetVisibility(OldPassword.Password, OldPasswordPlaceholder);
        }
        private void Password_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PlaceholderController.SetVisibility(Password.Password, PasswordPlaceholder);
        }

        private void ChangePasswordButton_Click(object sender, RoutedEventArgs e)
        {
            if (Login.Text.Length == 0)
            {
                MessageBox.Show("Логин не может быть пустым!");
                return;
            }

            BookStoreEntities context = BookStoreDB.GetContext();
            if (context.Accounts.Any(x => x.Login == Login.Text))
            {
                var account = context.Accounts.Where(x => x.Login == Login.Text).First();
                if (HashCoder.GetHashCode(OldPassword.Password) == account.Password)
                {
                    if (ValidatePassword(Password.Password))
                    {
                        account.Password = HashCoder.GetHashCode(Password.Password);
                        context.SaveChanges();
                        NavigationService?.Navigate(new AuthorizationPage());
                    }
                    else
                    {
                        MessageBox.Show("Новый пароль не соответсвует требованиям(одному или нескольким):\n" +
                            "\t- пароль должен содержать 6 или более символов;\n" +
                            "\t- допускается только английская раскладка;\n" +
                            "\t- пароль должен содержать хотя бы одну цифру.\n" +
                            "Пароль также может отсутствовать");
                    }
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

        private bool ValidatePassword(string password)
        {
            if (password.Length == 0)
            {
                return true;
            }

            return password.Length > 6 && password.Any(char.IsDigit) && password.All(char.IsLetterOrDigit);
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new AuthorizationPage());
        }
    }
}
