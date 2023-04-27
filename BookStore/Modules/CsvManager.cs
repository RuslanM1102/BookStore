using BookStore.DatabaseModels;
using CsvHelper;
using Microsoft.Win32;
using BookStore.Modules;
using System.IO;
using System.Globalization;
using System.Linq;
using System.Collections.Generic;

namespace BookStore.Modules
{
    internal class CsvManager
    {
        public static void Export<T>()
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
                var properties = typeof(T).GetProperties()
                    .Where(p => p.GetGetMethod().IsVirtual == false)
                    .Select(x => x.Name);

                var properties2 = typeof(T).GetProperties()
                .Where(p => p.GetGetMethod().IsVirtual && p.PropertyType.IsGenericType && 
                    p.PropertyType.GetGenericTypeDefinition() == typeof(ICollection<>))
                .Select(x => x.Name);

                foreach (var prop in ReflectionPropertyFinder.FindProperties<Nomenclature>())
                {
                    csv.WriteField(prop);
                    csv.NextRecord();
                }
            }
        }

        public static void Import()
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
        }
    }
}
