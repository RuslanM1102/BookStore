using BookStore.DatabaseModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Modules
{
    static class ReflectionPropertyFinder
    {
        public static IEnumerable<PropertyInfo> FindColumns(DbSet dbSet)
        {
            var props = dbSet.ElementType.GetProperties()
                .Where(p => p.GetGetMethod().IsVirtual == false)
                .Select(x => x);

            return props;
        }

        public static IEnumerable<PropertyInfo> FindForeignTables(DbSet dbSet)
        {
            var props = dbSet.ElementType.GetProperties()
            .Where(p => p.GetGetMethod().IsVirtual && !p.PropertyType.IsGenericType)
            .Select(x => x);

            return props;
        }

        public static IEnumerable<PropertyInfo> FindManyToManyTables(DbSet dbSet)
        {
            var properties = dbSet.ElementType.GetProperties()
            .Where(p => p.GetGetMethod().IsVirtual && p.PropertyType.IsGenericType &&
                p.PropertyType.GetGenericTypeDefinition() == typeof(ICollection<>))
            .Select(x => x);

            var props = properties.Where(x => x.PropertyType.GenericTypeArguments[0].GetProperties().Any(p => p.PropertyType == dbSet.ElementType))
                .Select(x => x);

            return props;
        }
    }
}
