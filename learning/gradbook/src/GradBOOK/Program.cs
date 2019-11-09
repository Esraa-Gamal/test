using System;
using System.Collections.Generic;

namespace GradBOOK
{
    class Program
    {
        static void Main(string[] args)
        {
            var book =new Book("");

            while(true)
            {
                Console.WriteLine("Enter a grade or 'q' to quit");
                var input = Console.ReadLine();
                if (input=="q")
                {           
                    break;
                }

                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
                catch(FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("*****");
                }

               
            }

            var stats = book.GetStatistics();

            Console.WriteLine($"Average= {stats.Average:N3}");
            Console.WriteLine($"The highest={stats.High}");
            Console.WriteLine($"The Lowest={stats.Low}");
            Console.WriteLine($"The grade letter is {stats.letter}");

          
        }
    }
}
