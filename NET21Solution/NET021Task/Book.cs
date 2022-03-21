using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace NET021Task
{
    public class Book
    {
        public string ISBN { get; }
        public string Title { get; }
        public DateTime? PublicationDate { get; }
        public Author[]? BookAuthors { get; }

        public static Regex ISBNPattern1 = new Regex(@"^[0-9]{13}$");
        public static Regex ISBNPattern2 = new Regex(@"^[0-9]{3}\-[0-9]\-[0-9]{2}\-[0-9]{6}\-[0-9]$");

        public Book(string isbn, string title, DateTime date, Author[] authors)
        {
            if (ISBNPattern1.IsMatch(isbn))
            {
                ISBN = isbn;
            }
            else if (ISBNPattern2.IsMatch(isbn))
            {
                ISBN = Regex.Replace(isbn, @"[^0-9]", ""); ;
            }
            else
            {
                throw new ArgumentException(nameof(isbn), "ISBN format not supported");
            }

            Title = (String.IsNullOrEmpty(title) || title.Length > 1000) ? throw new ArgumentException(nameof(title), "Book title cannot be empty or longer than 1000 chars") : title;

            PublicationDate = date;
            BookAuthors = authors;
        }

        public Book()
        {

        }

        public override bool Equals(object? obj)
        {
            var other = obj as Book;
            return other != null && ISBN.Equals(other.ISBN);
        }

        public override int GetHashCode()
        {
            return ISBN.GetHashCode();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            StringBuilder authors = new StringBuilder();
            Array.ForEach(BookAuthors, x => authors.Append($"{x.ToString()}, "));
            sb.Append($"ISBN: {ISBN} / Title: {Title} / Publication Date: {PublicationDate} / Author(s): {authors}");
            return sb.ToString();
        }
    }
}
