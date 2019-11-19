using GradBOOK;
using System;
using Xunit;


namespace GradeBook.Tests
{
    public class TestGradeBook
    {
        [Fact]
        public void BookCalculatesAveragegrade()
        {
            #region Arrange Section
            var book =new InMemoryBook("");
            book.AddGrade(98.2);
            #endregion

            #region Actual Result
            var result = book.GetStatistics();
            #endregion

            #region Assertion
            Assert.Equal(55.4, result.Average, 1);  
            Assert.Equal(98.2, result.High, 1);
            Assert.Equal(12.6, result.Low, 2);
            Assert.Equal('B', result.Letter);
            #endregion
        }
    }
}
