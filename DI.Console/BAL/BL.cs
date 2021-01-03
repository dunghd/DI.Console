using DI.Console.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace DI.Console.BAL
{
    public class BL
    {
        private readonly IBook _objIBook;

        public BL(IBook objIBook)
        {
            _objIBook = objIBook;
        }

        public void Insert()
        {
            _objIBook.InsertBook();
        }
    }
}
