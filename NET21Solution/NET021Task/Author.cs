using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET021Task
{
    public class Author
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public Author(string firstName, string lastName)
        {
            FirstName = (String.IsNullOrEmpty(firstName) || firstName.Length > 200) ? throw new ArgumentOutOfRangeException(nameof(firstName), "First name cannot be empty or longer than 200 chars") : firstName;
            LastName = (String.IsNullOrEmpty(lastName) || lastName.Length > 200) ? throw new ArgumentOutOfRangeException(nameof(lastName), "Last name cannot be empty or longer thn 200 chars") : lastName;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{FirstName} {LastName}");
            return sb.ToString();
        }

    }
}
