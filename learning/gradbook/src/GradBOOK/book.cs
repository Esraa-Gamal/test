using System.Collections.Generic;
using System;

namespace GradBOOK
{

    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public class Book

    {
        public Book(string name)
        {
            grades=new List<double>();
            Name = name;
       
        }

        public void AddLetterGrade(char letter)
        { 
           switch(letter)
                {
                    case 'A':
                        AddGrade(90);
                        break;
                    case 'B':
                        AddGrade(80);
                        break;
                    case 'C':
                        AddGrade(70);
                        break;
                    case 'D':
                        AddGrade(60);
                        break;
                    default:
                        AddGrade(0);
                        break;
                }
        }
    


        public void AddGrade(double grade)
        {

            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
                GradeAdded?.Invoke(this, new EventArgs());
                /* if (GradeAdded != null)
                 {
                   GradeAdded(this, new EventArgs());
                 }*/
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        
        }
        public event GradeAddedDelegate GradeAdded;

  

        public Statistics GetStatistics()
        {
               // var grades = new List<double>() { 12.9, 45.657, 36.298, 22.5 };
                grades.Add(12.6);
                var result = new Statistics();
                result.Average = 0.0;
                result.High = double.MinValue;
                result.Low = double.MaxValue;

      

                for (var index=0 ; index < grades.Count; index++)
                {
                    /*if(grades[index]==0)
                    {
                        goto done;
                    }*/
                    result.High = Math.Max(grades[index], result.High);
                    result.Low = Math.Min(grades[index], result.Low);
                    result.Average += grades[index];
                    index += 1;
                }
           
          
                result.Average /= grades.Count;
               // done:
               switch(result.Average)
                {
                    case var d when d >= 90.0:
                        result.letter = 'A';
                        break;
                    case var d when d >= 80.0:
                        result.letter = 'B';
                        break;
                    case var d when d >= 70.0:
                        result.letter = 'C';
                        break; 
                    case var d when d >= 60.0:
                        result.letter = 'D';
                        break;
                    default:
                        result.letter = 'F';
                        break;

                }
                return result;
          
            }

            private  List <double> grades;

            public string Name
            {
                //The Auto property in C#
                 get; 
                //to set the name Read only define set as Private
                 set;
                }
        
            /*
             readonly is a field that can only initialize or change or write to
             in the constructor;
             so we can only use initializer here to set a category 
             or in the constructor Method
             const members can't be redefined even in constructor methods 
             or even with increment operators
             */

             public const string CATEGORY="Science";
        

    }
    }