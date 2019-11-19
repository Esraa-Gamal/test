using System.Collections.Generic;
using System;
using System.IO;

namespace GradBOOK
{

    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public class NamedObject
    {

        public NamedObject(string name)
        {
            Name = name;
        }
        public string Name
        {
            get;
            set;
        }
    }

    public interface IBook
    {
        void AddGrade(double grade);
        Statistics GetStatistics();
        string Name { get; }
        event GradeAddedDelegate GradeAdded;
    }

    public abstract class Book : NamedObject, IBook
    {
        public Book(string name) : base(name)
        {
        }

        public virtual event GradeAddedDelegate GradeAdded;

        public abstract void AddGrade(double grade);

        public abstract Statistics GetStatistics();
      
    }
    public class DiskBook : Book
    {
        public DiskBook (string name): base(name)
        {

        }

        public override event GradeAddedDelegate GradeAdded;
        public override void AddGrade(double grade)
        {
            using (var writer = File.AppendText($"{Name}.txt"))
            {
                writer.WriteLine(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
                
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();
            using (var reader=File.OpenText($"{Name}.txt"))
            {
                var line= reader.ReadLine();
                while(line!=null)
                {
                    var number = double.Parse(line);
                    result.Add(number);
                    line = reader.ReadLine();
                }
            }


            return result;
        }
    }
    public class InMemoryBook : Book

    {
        public InMemoryBook(string name) : base(name)
        {
         
            grades=new List<double>();
            Name = name;
        
        }

        public override void AddGrade(double grade)
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
        public override event GradeAddedDelegate GradeAdded;

  

        public override Statistics GetStatistics()
        {
            var result = new Statistics();

            for (var index=0 ; index < grades.Count; index++)
            {
                result.Add(grades[index]);   
            }
             return result;      
        }

            private  List <double> grades;

          /*  public string Name
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