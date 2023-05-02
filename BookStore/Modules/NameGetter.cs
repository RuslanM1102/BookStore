using BookStore.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BookStore.Modules
{
    public class NameGetter
    {
        public static string GetName<T>(T obj, string foreignName) where T : class
        {
            if (typeof(T) == typeof(Authors))
            {
                return $"{foreignName}.Surname + {foreignName}.Name {foreignName}.Patronymic";
            }
            else
            {
                if(BookStoreDB.GetContext().GetType().GetProperty(foreignName).GetGetMethod().ReturnType.GetGenericArguments()[0].GetProperty("Name") != null)
                {
                  return $"{foreignName}.Name";
                }
                else
                {
                    return default;
                }
            }
        }

        public static string GetName(dynamic obj)
        {
            if (obj is Authors author)
            {
                return $"{author.Surname} + {author.Name} + {author.Patronymic}";
            }
            else
            {
                if (obj.GetType().GetProperty("Name") != null)
                {
                    return $"{obj.GetType().GetProperty("Name").GetValue(obj)}";
                }
                else
                {
                    return default;
                }
            }
        }
    }
}
