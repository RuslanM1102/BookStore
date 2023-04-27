using BookStore.DatabaseModels;
using CsvHelper;
using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Threading;
using System.Linq;
using BookStore.Modules;
using System.Windows.Input;
using System.Windows.Navigation;
using BookStore.Pages.Auth;

namespace BookStore
{
    /// <summary>
    /// Логика взаимодействия для MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        private bool _openAuth = false;
        public MainMenu()
        {
            InitializeComponent();
            DataContext = new DateTimeViewModel();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DispatcherTimer timer = new DispatcherTimer();

            timer.Tick += new EventHandler((s, ee) => ((DateTimeViewModel)DataContext).CurrentDateTime = DateTime.Now.ToString("dd.MM.yyyy, HH:mm:ss"));
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            if (!_openAuth)
            {
                e.Cancel = MessageBox.Show(this, "Вы уверены?", "Выход",
                    MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes) == MessageBoxResult.No;
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            _openAuth = true;
            new MainWindow().Show();
            Close();
        }

        private void Nomenclature_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new PasswordPage());
        }

        private void Export_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "csv files (*.csv)|*.csv";
            if(saveFileDialog.ShowDialog() != true)
            {
                return;
            }

            string path = saveFileDialog.FileName;
            using (CsvWriter csv = new CsvWriter(new StreamWriter(path), CultureInfo.CurrentCulture))
            {
                var db = BookStoreDB.GetContext();
                foreach (var publisher in db.Publishers)
                {
                    csv.WriteField(publisher.ID);
                    csv.WriteField(publisher.Name);
                    csv.NextRecord();
                }
            }
            MessageBox.Show("Экспорт завершён");
        }
        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ThemeController.SwitchTheme();
        }

        private void Import_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "csv files (*.csv)|*.csv";
            if (openFileDialog.ShowDialog() != true)
            {
                return;
            }

            string path = openFileDialog.FileName;
            using (CsvReader csv = new CsvReader(new StreamReader(path), CultureInfo.CurrentCulture))
            {
                var db = BookStoreDB.GetContext();
                while (csv.Read())
                {
                    var name = csv.GetField(1);
                    Publishers publisher = new Publishers();
                    publisher.Name = name;
                    db.Publishers.Add(publisher);
                }
                db.SaveChanges();
            }
            MessageBox.Show("Импорт завершён");
        }
    }

    public class DateTimeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _currentDateTime;
        public string CurrentDateTime
        {
            get => _currentDateTime;
            set
            {
                _currentDateTime = value;
                OnPropertyChanged(nameof(CurrentDateTime));
            }
        }
    }
}
