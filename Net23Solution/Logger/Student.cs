using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerApp
{
    [TrackingEntity]
    class Student
    {
        [TrackingProperty]
        public readonly int ID;

        [TrackingProperty("NameAttr")]
        public string Name { get; }

        [TrackingProperty]
        public int Age { get; }

        [TrackingProperty("Phone number Attr")]
        public string PhoneNumber { get; set; }

        [TrackingProperty]
        public string EmailAddress { get; set; }

        public Student(int id, string name, int age, string phone, string email)
        {
            ID = id;
            Name = name;
            Age = age;
            PhoneNumber = phone;
            EmailAddress = email;
        }

        public int GetYearOfBirth()
        {
            int dob = (int)DateTime.Today.Year - Age;
            return dob;
        }

        public override string ToString()
        {
            StringBuilder temp = new();
            temp.Append($"Person Name: {Name}, Age: {Age}, Phone Nr.: {PhoneNumber}, Email: {EmailAddress}");
            return temp.ToString();
        }
    }
}
