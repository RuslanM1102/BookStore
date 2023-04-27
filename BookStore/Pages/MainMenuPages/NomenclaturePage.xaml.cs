using BookStore.DatabaseModels;
using BookStore.Modules;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
namespace BookStore.Pages.MainMenuPages
{
    /// <summary>
    /// Логика взаимодействия для NomenclaturePage.xaml
    /// </summary>
    public partial class NomenclaturePage : Page
    {
        public NomenclaturePage()
        {
            InitializeComponent();
            Table.ItemsSource = BookStoreDB.GetContext()
                .Nomenclature.Select(x => new
                {
                    Name = x.Name,
                    Pages = x.Pages,
                }).ToList();
        }

        private void Export_Click(object sender, RoutedEventArgs e)
        {
            CsvManager.Export<Nomenclature>();
        }
    }
}
