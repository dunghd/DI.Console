namespace DI.Console
{
    using DI.Console.Controllers;
    using DI.Console.Interface;
    using Ninject;
    using System;
    using System.Reflection;

    class Program
    {
        static void Main(string[] args)
        {
            // Initializes a new instance of the Ninject.StandardKernel class.
            StandardKernel _kernel = new StandardKernel();

            // Load Modules
            _kernel.Load(Assembly.GetExecutingAssembly());

            // Gets an instance of the specified service
            IBookService bookService = _kernel.Get<IBookService>();

            // Ninject will inject DL object to BL
            BookController bookController = new BookController(bookService);

            // Calling method of BL from that Dependency

            // Read all
            var listBooks = bookController.GetAll();
            foreach (var item in listBooks)
            {
                Console.WriteLine(item);
            }
            // Read all

            // Insert
            var newBook = "New book DDH";
            bookController.Insert(newBook);
            // Insert

            // Update
            bookController.Update("Book F", "New book DDH");
            // Update

            // Delete
            bookController.Delete("New book DDH");
            // Delete

            Console.ReadKey();
        }
    }
}
