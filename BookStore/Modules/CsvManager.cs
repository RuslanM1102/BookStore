using BookStore.DatabaseModels;
using CsvHelper;
using Microsoft.Win32;
using System.Reflection;
using System.IO;
using System.Globalization;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;
using System.Windows;
using System;

namespace BookStore.Modules
{
    internal class CsvManager
    {
        public static void Export(DbSet dbSet)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "csv files (*.csv)|*.csv";
                if (saveFileDialog.ShowDialog() != true)
                {
                    return;
                }

                string path = saveFileDialog.FileName;
                using (CsvWriter csv = new CsvWriter(new StreamWriter(path), CultureInfo.CurrentCulture))
                {
                    var context = BookStoreDB.GetContext();
                    var columnsNames = ReflectionPropertyFinder.FindColumns(dbSet);
                    var type = dbSet.ElementType;
                    foreach (var record in dbSet)
                    {
                        foreach (var prop in columnsNames)
                        {
                            csv.WriteField(prop.GetValue(record));
                        }
                        csv.NextRecord();
                    }
                }
                MessageBox.Show("Экспорт завершён");
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Произошла ошибка\n{exception.Message}");
            }

        }

        public static void Import(DbSet dbSet)
        {
            try
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
                    var context = BookStoreDB.GetContext();
                    var columnsNames = ReflectionPropertyFinder.FindColumns(dbSet).ToList();
                    var type = dbSet.ElementType;

                    while (csv.Read())
                    {
                        var record = Activator.CreateInstance(type);

                        for (int i = 1; i < columnsNames.Count; i++)
                        {
                            var value = Convert.ChangeType(csv.GetField(i), type.GetProperty(columnsNames[i].Name).PropertyType);
                            type.GetProperty(columnsNames[i].Name).SetValue(record, value);
                        }
                        dbSet.Add(record);
                    }
                    db.SaveChanges();
                    MessageBox.Show("Импорт завершён");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Произошла ошибка\n{exception.Message}");
            }
        }
    }
}
