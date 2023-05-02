using BookStore.DatabaseModels;
using BookStore.Modules;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Windows;
using System.Windows.Controls;
using System.Reflection;

namespace BookStore.Pages.MainMenuPages
{
    /// <summary>
    /// Логика взаимодействия для NomenclaturePage.xaml
    /// </summary>
    public partial class TablePage : Page
    {
        public static dynamic CurrentDbSet { get; private set; }
        public static dynamic CurrentItem { get; private set; }

        public TablePage()
        {
            InitializeComponent();
            TableSelector.ItemsSource = BookStoreDB.GetContext().GetType().GetProperties().Where(x => x.DeclaringType == typeof(BookStoreEntities)).Select(x => x.Name).ToList();
            CurrentDbSet = null;
            CurrentItem = null;
        }

        private void Export_Click(object sender, RoutedEventArgs e)
        {
            if(TableSelector.SelectedItem == null)
            {
                return;
            }

            CsvManager.Export(GetCurrentDbSet());
        }

        private void Import_Click(object sender, RoutedEventArgs e)
        {
            if (TableSelector.SelectedItem == null)
            {
                return;
            }

            CsvManager.Import(GetCurrentDbSet());
            Table.ItemsSource = BookStoreDB.GetItemsSource(GetCurrentDbSet());
        }

        private void AddEdit_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentDbSet == null)
                return;
            NavigationService?.Navigate(new AddEditPage());
        }

        private void TableSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Table.ItemsSource = BookStoreDB.GetItemsSource(GetCurrentDbSet());
        }

        private dynamic GetCurrentDbSet()
        {
            var context = BookStoreDB.GetContext();
            var tableName = TableSelector.SelectedValue.ToString();
            PropertyInfo property = typeof(BookStoreEntities).GetProperty(tableName);
            CurrentDbSet = property.GetValue(context);
            return CurrentDbSet;
        }

        private void ClearSelection(object sender, RoutedEventArgs e)
        {
            Table.UnselectAll();
        }

        private void DeleteSelection(object sender, RoutedEventArgs e)
        {
            try
            {
                if(CurrentItem == null)
                {
                    return;
                }

                int id = CurrentItem.ID;
                CurrentItem = ((IQueryable)CurrentDbSet).Where("ID = @0", id).FirstOrDefault();
                CurrentDbSet.Remove(CurrentItem);
                BookStoreDB.GetContext().SaveChanges();
                Table.ItemsSource = BookStoreDB.GetItemsSource(GetCurrentDbSet());
            }
            catch
            {
                MessageBox.Show("Произошла непредвиденная ошибка");
            }
        }

        private void Table_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CurrentItem = Table.SelectedValue;
        }
    }
}
