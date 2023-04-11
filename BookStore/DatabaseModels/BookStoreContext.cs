using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DatabaseModels
{
    static class BookStoreContext
    {
        private static BookStoreEntities _context;

        public static BookStoreEntities GetContext()
        {
            if(_context == null)
            {
                _context = new BookStoreEntities();
            }
            return _context;
        }
    }
}
