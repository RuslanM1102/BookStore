using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

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
            DispatcherTimer timer = new DispatcherTimer();

            timer.Tick += new EventHandler((s, ee) => ((DateTimeViewModel)DataContext).CurrentDateTime = DateTime.Now.ToString("dd.MM.yyyy, HH:mm:ss"));
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            e.Cancel = MessageBox.Show(this, "Вы уверены?", "Выход",
                MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes) == MessageBoxResult.No;
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
