namespace DI.Console.Test
{
    using DI.Console.Interface;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using FluentAssertions;
    using System.Collections.Generic;
    using DI.Console.Controllers;

    [TestClass]
    public class BookStoreTest
    {
        [TestMethod]
        public void TestGetAllBooks()
        {
            var bookService = new Mock<IBookService>();

            bookService.Setup(b => b.GetAll()).Returns(GetListBooks());

            var controller = new BookController(bookService.Object);

            var listBooksActual = controller.GetAll();
            var listBooksExpected = GetListBooks();

            listBooksActual.Should().HaveCount(listBooksExpected.Count);
            listBooksActual.Should().BeEquivalentTo(listBooksExpected);
        }

        [TestMethod]
        public void TestInsertBook()
        {
            var bookService = new Mock<IBookService>();

            var bookInserted = new List<string>();
            var newBook = "Book F";

            bookService
                .Setup(repo => repo.InsertBook(It.IsAny<string>()))
                .Callback(() => bookInserted.Add(newBook));

            var controller = new BookController(bookService.Object);

            controller.Insert(newBook);

            bookInserted.Should().Contain(newBook);
        }

        [TestMethod]
        public void TestUpdateBook()
        {
            var bookService = new Mock<IBookService>();

            var bookUpdated = "Book F";
            var bookNew = $"{bookUpdated} + _UPDATED";
            var listBooks = new List<string> { bookUpdated };

            bookService
                .Setup(repo => repo.UpdateBook(It.IsAny<string>(), It.IsAny<string>()))
                .Callback(() =>
                {
                    listBooks.Remove(bookUpdated);
                    listBooks.Add(bookNew);
                });

            var controller = new BookController(bookService.Object);

            controller.Update(bookUpdated, bookNew);

            listBooks.Should().NotContain(bookUpdated);
            listBooks.Should().Contain(bookNew);
        }

        [TestMethod]
        public void TestDeleteBook()
        {
            var bookService = new Mock<IBookService>();

            var bookDeleted = "Book F";
            var listBooks = new List<string> { bookDeleted };

            bookService
                .Setup(repo => repo.UpdateBook(It.IsAny<string>(), It.IsAny<string>()))
                .Callback(() =>
                {
                    listBooks.Remove(bookDeleted);
                    listBooks.Add(string.Empty);
                });

            var controller = new BookController(bookService.Object);

            controller.Delete(bookDeleted);

            listBooks.Should().NotContain(bookDeleted);
        }

        private List<string> GetListBooks()
        {
            return new List<string>()
            {
                "Book A",
                "Book B",
                "Book C",
                "Book D",
                "Book E",
                "Book G",
                "Book H",
                "Book I",
                "Book K"
            };
        }
    }
}
