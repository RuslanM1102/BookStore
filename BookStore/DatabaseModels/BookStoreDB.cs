using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DatabaseModels
{
    class BookStoreDB
    {
        private static BookStoreEntities s_entities;
        
        public static BookStoreEntities GetContext() => s_entities = s_entities ?? new BookStoreEntities();
    }
}
