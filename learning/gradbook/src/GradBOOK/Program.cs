using System;
using System.Collections.Generic;

namespace GradBOOK
{
    class Program
    {
        static void Main(string[] args)
        {
            var book =new Book("");
            book.AddGrade(55.3);
            book.AddGrade(13.5);
            var status = book.GetStatistics();

            Console.WriteLine($"Average= {status.Average:N3}");
            System.Console.WriteLine($"The highest={status.High}");
            System.Console.WriteLine($"The Lowest={status.Low}");

          
        }
    }
}
