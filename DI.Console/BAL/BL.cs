namespace DI.Console.BAL
{
    using DI.Console.Interface;
    using System.Collections.Generic;

    public class BL
    {
        private readonly IBook _objIBook;

        public BL(IBook objIBook)
        {
            _objIBook = objIBook;
        }

        public IList<string> GetAll()
        {
            return _objIBook.GetAll();
        }

        public void Insert(string book)
        {
            _objIBook.InsertBook(book);
        }

        public void Update(string bookId, string newBook)
        {
            _objIBook.UpdateBook(bookId, newBook);
        }

        public void Delete(string bookId)
        {
            _objIBook.UpdateBook(bookId, string.Empty);
        }
    }
}
