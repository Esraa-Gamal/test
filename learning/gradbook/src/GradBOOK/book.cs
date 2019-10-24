using System.Collections.Generic;
using System;

namespace GradBOOK
{
public class Book

{
    public Book()
    {
        grades=new List<double>();
       
    }
    


    public void AddGrade(double grade)
    {
        grades.Add(grade);
    }
  

    public Statistics GetStatistics()
    {
            var grades = new List<double>() { 12.9, 45.657, 36.298, 22.5 };
            grades.Add(12.6);


            var result = new Statistics();
            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;
            foreach (var grade in grades)
            {
                result.High = Math.Max(grade, result.High);
                result.Low = Math.Min(grade, result.Low);
                result.Average += grade;
            }
          
             result.Average /= grades.Count;
            return result;
          
        }

        public  List <double> grades;

}
}