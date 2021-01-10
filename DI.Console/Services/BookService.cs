namespace DI.Console.Services
{
    using DI.Console.Interface;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class BookService : IBookService
    {
        private readonly string _textFile = @"C:\Users\dzunh\Source\Repos\DI.Console\DI.Console\DataSource\Books.txt";

        public IList<string> GetAll()
        {
            var listBooks = new List<string>();

            // Read file using StreamReader. Reads file line by line    
            using (StreamReader file = new StreamReader(_textFile))
            {
                string ln;

                while ((ln = file.ReadLine()) != null)
                {
                    listBooks.Add(ln);
                }
                file.Close();
            }

            return listBooks;
        }

        public void InsertBook(string book)
        {
            using (StreamWriter file = new StreamWriter(_textFile, true))
            {
                file.Write(Environment.NewLine + book);
            }
        }

        public void UpdateBook(string bookId, string newBook)
        {
            var listBooks = GetAll();

            var listUpdatedBooks = listBooks.Select(book => book.Replace(bookId, newBook));
            var lastBook = listUpdatedBooks.LastOrDefault();

            using (StreamWriter file = new StreamWriter(_textFile))
            {
                foreach (var item in listUpdatedBooks)
                {
                    if (string.IsNullOrEmpty(item))
                    {
                        continue;
                    }

                    if (item != lastBook)
                    {
                        file.WriteLine(item);
                    }
                    else
                    {
                        file.Write(item);
                    }
                }
            }
        }
    }
}
