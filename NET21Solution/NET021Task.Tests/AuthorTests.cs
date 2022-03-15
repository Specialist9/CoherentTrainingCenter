using Microsoft.VisualStudio.TestTools.UnitTesting;
using NET021Task;

namespace NET021Task.Tests
{
    [TestClass]
    public class AuthorTests
    {
        [TestMethod]
        public void Author_FirstNameLongerThan200char_ThrowsArgumentOutOfRangeException()
        {
            //Arrange
            string firstName = "yyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyy";
            string lastName = "xxxxxxxxx";
            //Author authorTest = new Author(firstName, lastName);

            //Act and Assert
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
        }
    }
}