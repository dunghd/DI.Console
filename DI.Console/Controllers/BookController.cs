namespace DI.Console.Controllers
{
    using DI.Console.Interface;
    using System.Collections.Generic;

    public class BookController
    {
        private readonly IBookService _bookService;

        public BookController(IBookService objIBook)
        {
            _bookService = objIBook;
        }

        public IList<string> GetAll()
        {
            return _bookService.GetAll();
        }

        public void Insert(string book)
        {
            _bookService.InsertBook(book);
        }

        public void Update(string bookId, string newBook)
        {
            _bookService.UpdateBook(bookId, newBook);
        }

        public void Delete(string bookId)
        {
            _bookService.UpdateBook(bookId, string.Empty);
        }
    }
}
