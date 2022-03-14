using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET021Task
{
    internal class Catalog
    {
        IEnumerable<Book> Books { get; set; }

        public Catalog()
        {
            Books = new List<Book>();
        }

        public Book this[string isbn]
        {
            get
            {
                if(Book.ISBNPattern1.Equals(isbn));
                bool bookExists = Books.Any(x => x.ISBN == isbn);
                return Books.Select(x => x.ISBN == isbn) as Book;
            }
        }
    }
}
