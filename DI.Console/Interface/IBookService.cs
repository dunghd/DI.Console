namespace DI.Console.Interface
{
    using System.Collections.Generic;

    public interface IBookService
    {
        IList<string> GetAll();

        void InsertBook(string book);

        void UpdateBook(string bookId, string newBook);
    }
}
