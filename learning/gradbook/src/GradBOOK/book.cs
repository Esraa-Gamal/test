using System.Collections.Generic;
using System;

namespace GradBOOK
{
public class Book

{
    public Book(string name)
    {
        grades=new List<double>();
        this.name= name;
    }
    public void AddGrade(double grade)
    {
        grades.Add(grade);
    }
    
    public void ShowStatistics()
    {   
        var result = 0.0;
        var grades = new List<double>() {12.9,45.657,36.298,22.5};
        grades.Add(12.6);
        var highestGrade = double.MinValue;
        var lowestGrade=double.MaxValue;
        foreach(var number in grades) 
        {
            highestGrade=Math.Max(number,highestGrade);
            lowestGrade=Math.Min(number,lowestGrade);
            result+=number;
        }
        var avg= result/grades.Count;
        Console.WriteLine($"Average= {avg:N3}");
        System.Console.WriteLine($"The highest={highestGrade}");
        System.Console.WriteLine($"The Lowest={lowestGrade}");
        System.Console.WriteLine($"no. of grades= {grades.Count}");
        System.Console.WriteLine($"Sum = {result:N2}");
      
    }
  private  List <double> grades;
  private string name;
}
}