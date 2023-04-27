using BookStore.DatabaseModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Modules
{
    static class ReflectionPropertyFinder
    {
        public static IEnumerable FindProperties<T>()
        {
            var context = BookStoreDB.GetContext();
            var properties = typeof(T).GetProperties()
                .Where(p => p.GetGetMethod().IsVirtual == false)
                .Select(x => x.Name);

            var properties2 = typeof(T).GetProperties()
            .Where(p => p.GetGetMethod().IsVirtual && p.PropertyType.IsGenericType &&
                p.PropertyType.GetGenericTypeDefinition() == typeof(ICollection<>))
            .Select(x => x);

            List<string> names = new List<string>();
            foreach(var prop in properties2)
            {
                Type type = prop.PropertyType.GetGenericArguments()[0];
                if(type.GetProperties().Any(x => x.PropertyType == typeof(ICollection<T>)))
                {
                    names.Add(prop.Name);
                }
            }
            return names;
        }
    }
}
