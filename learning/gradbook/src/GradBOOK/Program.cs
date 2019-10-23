using System;
using System.Collections.Generic;

namespace GradBOOK
{
    class Program
    {
        static void Main(string[] args)
        {
            var book =new Book("Esraa");
            book.AddGrade(55.3);
            book.AddGrade(13.5);
            book.ShowStatistics();   
        }
    }
}
