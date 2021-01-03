using DI.Console.Interface;
using System.Collections.Generic;
using System.Text;

namespace DI.Console.DAL
{
    using System;

    public class DL : IBook
    {
        public string InsertBook()
        {
            string value = "DI using Ninject";
            Console.WriteLine(value);

            return value;
        }
    }
}
