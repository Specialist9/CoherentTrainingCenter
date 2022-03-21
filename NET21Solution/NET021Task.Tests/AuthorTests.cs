using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NET021Task;

namespace NET021Task.Tests
{
    [TestClass]
    public class AuthorTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "First name cannot be empty or longer than 200 chars" )]
        public void Author_FirstNameLongerThan200char_ThrowsArgumentOutOfRangeException()
        {
            //Arrange
            string firstName = "yyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyy";
            string lastName = "xxxxxxxxx";

            //Act
            var author = new Author(firstName, lastName);
            /*
            try
            {
                var author = new Author(firstName, lastName);
            }
            catch(System.ArgumentOutOfRangeException ex)
            {
                //Assert
                StringAssert.Contains(ex.Message, "First name cannot be empty or longer than 200 chars");
                return;
            }
            //Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => new Author(firstName, lastName));
            
            Assert.Fail("Expected exception not thrown");
            */
        }
    }
}