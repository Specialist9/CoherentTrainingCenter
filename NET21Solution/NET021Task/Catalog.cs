using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET021Task
{
    public class Catalog : IEnumerable<Book>
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
                    return Books.First(x => x.ISBN.Equals(isbn));
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

        public List<Book> GetBooksByAuthorName(Author author)
        {
            return Books.Where(x => x.BookAuthors.Any(y => y.FirstName == author.FirstName && y.LastName == author.LastName)).ToList();
        }

        public List<Book> GetBooksByPublicationDateDesc()
        {
            return Books.OrderByDescending(x => x.PublicationDate).ToList();
        }

        public IEnumerable<Tuple<Author, int>> GetNumerOfBooksByAuthor()
        {
            return (from book in Books
                   from author in book.BookAuthors
                   group book by author into g
                   select new Tuple<Author, int>(item1: g.Key, item2 : g.Count())).ToList();

        }
    }
}
