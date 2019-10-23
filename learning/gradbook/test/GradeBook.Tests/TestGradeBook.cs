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
            var book=new book("");
            book.AddGrade(98.2);

            //Actual
            var result = book.ShowStatistics();
            //Assert
            Assert.Equal(50,result.avg);
        }
    }
}
