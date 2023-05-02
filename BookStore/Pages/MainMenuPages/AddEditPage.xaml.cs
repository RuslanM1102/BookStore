using System.Reflection;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Windows;
using System.Windows.Controls;
using BookStore.DatabaseModels;
using BookStore.Modules;
using System.Data.Entity;
using System.Collections.Generic;
using System;

namespace BookStore.Pages.MainMenuPages
{
    /// <summary>
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        private dynamic _dbSet, _currentRecord;
        private List<UIElement> _selectors = new List<UIElement>();
        public AddEditPage()
        {
            _dbSet = TablePage.CurrentDbSet;
            _currentRecord = TablePage.CurrentItem;
            if(_currentRecord != null)
            {
                int id = _currentRecord.ID;
                _currentRecord = ((IQueryable)_dbSet).Where("ID = @0", id).FirstOrDefault();
            }
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            int i = 0;
            var foreign = ReflectionPropertyFinder.FindForeignTables(_dbSet);
            foreach (var prop in ReflectionPropertyFinder.FindColumns(_dbSet))
            {
                Label propText = new Label();
                propText.Content = prop.Name;
                propText.Style = FindResource("PropertyLabel") as Style;
                var row = new RowDefinition();
                row.MaxHeight = 65;

                PropertiesGrid.RowDefinitions.Add(row);
                PropertiesGrid.Children.Add(propText);
                Grid.SetRow(propText, i);

                dynamic valueSelector = CreateSelector(prop, foreign);
                _selectors.Add(valueSelector);
                PropertiesGrid.Children.Add(valueSelector);
                Grid.SetColumn(valueSelector, 2);
                Grid.SetRow(valueSelector, i);
                i++;
            }
            PropertiesGrid.RowDefinitions.Add(new RowDefinition());

            if(_currentRecord != null)
            {
                i = 0;
                foreach (PropertyInfo prop in ReflectionPropertyFinder.FindColumns(_dbSet))
                {
                    dynamic selectorType = _selectors[i].GetType();
                    if (selectorType == typeof(ComboBox))
                    {
                        ((ComboBox)_selectors[i]).SelectedIndex = prop.GetValue(_currentRecord);
                    }
                    else if (selectorType == typeof(DatePicker))
                    {
                        ((DatePicker)_selectors[i]).SelectedDate = prop.GetValue(_currentRecord);
                    }
                    else
                    {
                        ((TextBox)_selectors[i]).Text = prop.GetValue(_currentRecord).ToString();
                    }
                    i++;
                }
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool isNewRecord = _currentRecord == null;

                if (isNewRecord)
                {
                    _currentRecord = Activator.CreateInstance(_dbSet.GetType().GetGenericArguments()[0]);
                }
                int i = 0;
                foreach (PropertyInfo prop in ReflectionPropertyFinder.FindColumns(_dbSet))
                {
                    dynamic selectorType = _selectors[i].GetType();

                    if (selectorType == typeof(ComboBox))
                    {
                        dynamic value = ((ComboBoxValue)((ComboBox)_selectors[i]).SelectedValue);
                        prop.SetValue(_currentRecord, value.ID);
                    }
                    else if (selectorType == typeof(DatePicker))
                    {
                        prop.SetValue(_currentRecord, ((DatePicker)_selectors[i]).SelectedDate);
                    }
                    else
                    {
                        if (prop.Name == "ID")
                        {
                            i++;
                            continue;
                        }
                        dynamic value = Convert.ChangeType(((TextBox)_selectors[i]).Text, prop.PropertyType);
                        prop.SetValue(_currentRecord, value);
                    }

                    i++;
                }

                if (isNewRecord)
                {
                    _dbSet.Add(_currentRecord);
                }
                BookStoreDB.GetContext().SaveChanges();
                NavigationService?.Navigate(new TablePage());
            }
            catch
            {
               MessageBox.Show("Произошла непредвиденная ошибка");
            }
        }

        private dynamic CreateSelector(PropertyInfo prop, IEnumerable<PropertyInfo> foreign)
        {
            string name = prop.Name;
            dynamic selector = new TextBlock();

            if (name.Length > 2 && name.Contains("ID"))
            {
                var a = new ComboBox();
 
                selector = new ComboBox();
                selector.Style = FindResource("ComboBox") as Style;
                selector.IsReadOnly = true;
                selector.IsEditable = true;
                selector.Text = "Не выбрано";
                
                name = name.Replace("ID", "");
                PropertyInfo foreignName = foreign.Where(x => x.Name.Contains(name.Substring(0, 3))).FirstOrDefault();

                dynamic valuesSet = typeof(BookStoreEntities).GetProperty(foreignName.Name).GetValue(BookStoreDB.GetContext()) as dynamic;
                foreach(dynamic value in valuesSet)
                {
                    selector.Items.Add(
                        new ComboBoxValue(value.ID, NameGetter.GetName(value), value)
                        );
                }
             
            }
            else if (prop.PropertyType == typeof(DateTime))
            {
                selector = new DatePicker();
            }
            else
            {
                selector = new TextBox();
                selector.Style = FindResource("DefaultTextBox") as Style;
                if(prop.Name == "ID")
                {
                    selector.IsReadOnly = true;
                }
            }

            return selector;
        }
    }
}
