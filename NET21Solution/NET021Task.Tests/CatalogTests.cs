﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace NET021Task.Tests
{
    [TestClass]
    public class CatalogTests
    {
        [TestMethod]
        public void AddBook_BookISBNExists_ThrowsInvalidOperationException()
        {
            //Arrange
            Book newBookX = new("1234567891238", "NewTitle27", new(2022, 03, 17), new[] { new Author ("James", "Bond") });
            Book newBookX2 = new("1234567891238", "NewTitle18", new(2022, 03, 18), new[] { new Author("Michael", "Jordan") });

            Catalog testCatalog = new();
            testCatalog.Books.Add(newBookX);

            //Act
            try
            {
                testCatalog.AddBook(newBookX2);
            }
            catch (InvalidOperationException ex)
            {
                //Assert
                StringAssert.Contains(ex.Message, "Book with given ISBN number already exists");
                return;
            }
            Assert.Fail("Expected exception not thrown");
        }
    }
}
