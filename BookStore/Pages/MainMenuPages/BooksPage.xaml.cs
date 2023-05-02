using BookStore.DatabaseModels;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

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
    }
}
