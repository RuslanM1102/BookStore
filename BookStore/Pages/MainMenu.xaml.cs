using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

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
