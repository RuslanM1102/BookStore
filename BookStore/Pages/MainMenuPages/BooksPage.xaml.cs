using BookStore.DatabaseModels;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Windows.Controls;
using BookStore.Modules;

namespace BookStore.Pages.MainMenuPages
{
    /// <summary>
    /// Логика взаимодействия для BooksPage.xaml
    /// </summary>
    public partial class BooksPage : Page
    {
        public BooksPage()
        {
            InitializeComponent();
            ListBooks.ItemsSource = BookStoreDB.GetItemsSource(BookStoreDB.GetContext().Nomenclature);
        }

        private void UpdateBooks()
        {
            dynamic currentSource = BookStoreDB.GetItemsSource(BookStoreDB.GetContext().Nomenclature);
            if (!string.IsNullOrWhiteSpace(SearchBox.Text))
            {
                currentSource = currentSource.Where("Name.Contains(@0)", SearchBox.Text);
            }

            if (CheckFormat.IsChecked == true)
            {
                currentSource = currentSource.Where("Format == @0", "Твёрдая обложка");
            }

            if(OrderBox.SelectedIndex == 0)
            {
                currentSource = currentSource.OrderBy("Name");
            }
            else
            {
                currentSource = currentSource.OrderBy("Name desc");
            }

            ListBooks.ItemsSource = currentSource;
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            PlaceholderController.SetVisibility(SearchBox.Text, SearchPlaceholder);
            UpdateBooks();
        }

        private void OrderBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateBooks();
        }

        private void CheckFormat_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }
    }
}
