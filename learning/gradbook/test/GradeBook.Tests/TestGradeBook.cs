using GradBOOK;
using System;
using Xunit;


namespace GradeBook.Tests
{
    public class TestGradeBook
    {
        [Fact]
        public void Test1()
        {
            //arrange Section
            var book=new Book();
            book.AddGrade(98.2);

            //Actual
            var result = book.GetStatistics();
            //Assert
            Assert.Equal(50,result.Average,1);
            Assert.Equal(98.2, result.High,1);
            Assert.Equal(12.6, result.Low,2);
            
        }
    }
}
