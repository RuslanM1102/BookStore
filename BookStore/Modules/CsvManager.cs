using BookStore.DatabaseModels;
using CsvHelper;
using Microsoft.Win32;
using System;
using System.IO;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity.Core.Metadata.Edm;
using System.Globalization;
using System.Linq;

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

                foreach(var prop in properties)
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
