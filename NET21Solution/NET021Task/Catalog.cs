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

        public List<Book> GetBooksByAuthorName(string firstName, string lastName)
        {
            return Books.Where(x => x.BookAuthors.Any(y => y.FirstName == firstName && y.LastName == lastName)).ToList();
        }

        public List<Book> GetBooksByPublicationDateDesc()
        {
            return Books.OrderByDescending(x => x.PublicationDate).ToList();
        }

        public List<(Author[], int)> GetNumerOfBooksByAuthor() //This doesn't work
        {
            /*return Books.GroupBy(g => g.BookAuthors).
                Select(g => new { Authors = g.Key, NumberOfBooks = g.Count() })
                .Select(t => new Tuple<Author[], int>(t.Authors, t.NumberOfBooks))
                .ToList();*/
            throw new NotImplementedException();
         
        }
    }
}
