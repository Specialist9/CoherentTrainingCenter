using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET021Task
{
    internal class Catalog : IEnumerable<Book>
    {
        public List<Book> Books { get; private set; }

        public Catalog()
        {
            Books = new List<Book>();
        }

        public Book this[string isbn]
        {
            get
            {
                if (!Book.ISBNPattern1.IsMatch(isbn))
                {
                    throw new ArgumentException(nameof(isbn), "ISBN format not supported");
                }
                else if (!Books.Any(x => x.ISBN.Equals(isbn)))
                {
                    throw new KeyNotFoundException("ISBN key not found");
                }
                else
                {
                    return Books.First(x => x.ISBN.Equals(isbn)) as Book;
                }
            }
        }

        public void AddBook(Book book)
        {
            if (Books.Any(x => x.ISBN == book.ISBN))
            {
                throw new InvalidOperationException("Book with given ISBN number already exists");
            }
            else
            {
                Books.Add(book);
            }
        }

        public IEnumerator<Book> GetEnumerator()
        {
            return Books.OrderBy(x => x.Title).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)Books).GetEnumerator();
        }
    }
}
