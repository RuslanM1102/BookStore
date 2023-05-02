using BookStore.Modules;
using System;
using System.Collections;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Reflection;

namespace BookStore.DatabaseModels
{
    class BookStoreDB
    {
        private static BookStoreEntities s_entities;
        
        public static BookStoreEntities GetContext() => s_entities = s_entities ?? new BookStoreEntities();

        public static dynamic GetItemsSource(DbSet dbSet) 
        {
            var props = ReflectionPropertyFinder.FindColumns(dbSet).Select(x => x.Name).ToList();
            var foreign = ReflectionPropertyFinder.FindForeignTables(dbSet).Select(x => x.Name).ToList();
            for (int i = 0; i < props.Count; i++)
            {
                string name = props[i];
                if (name.Length <= 2)
                {
                    continue;
                }

                if (name.Contains("ID"))
                {
                    name = name.Replace("ID", "");
                    string foreignName = foreign.Where(x => x.Contains(name.Substring(0,3))).FirstOrDefault();
                    if (foreignName != default)
                    {
                        string newName = NameGetter.GetName(dbSet.GetType().GetGenericArguments()[0], foreignName);
                        if (newName != default)
                        {
                            props[i] = $"{newName} as {name}";
                        }
                    }
                }
            }

            var selected = "new {" + string.Join(",", props.ToArray()) + "}";
            return dbSet.Select(selected).ToDynamicList();
        }
    }
}
