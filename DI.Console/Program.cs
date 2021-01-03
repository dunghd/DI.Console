namespace DI.Console
{
    using DI.Console.BAL;
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
            IBook _objIBook = _kernel.Get<IBook>();

            // Ninject will inject DL object to BL
            BL objbl = new BL(_objIBook);

            // Calling method of BL from that Dependency

            // Read all
            //var listBooks = objbl.GetAll();
            //foreach (var item in listBooks)
            //{
            //    Console.WriteLine(item);
            //}
            // Read all

            // Insert
            //var newBook = "New book DDH";
            //objbl.Insert(newBook);
            // Insert

            // Update
            objbl.Update("Book F", "New book DDH");
            // Update

            // Delete
            objbl.Delete("New book DDH");
            // Delete

            Console.ReadKey();
        }
    }
}
