using GradBOOK;
using System;
using Xunit;


namespace GradeBook.Tests
{

    public delegate string WriteLogDelegate(string logMessage);


    public class TypeTests
    {
        int count = 0;
        [Fact]
        public void WritelohDelegateCanPointToMethod()
        {
            Console.WriteLine("${count}      ");
            WriteLogDelegate log = ReturnMessage;
            Console.WriteLine("${count}      ");
            // log = new WriteLogDelegate(ReturnMessage);
            log += ReturnMessage;
            Console.WriteLine("${count}      ");
            log += IncrementCount;
            Console.WriteLine("${count}      ");
            var result = log("Hello!");
            Console.WriteLine("${count}      ");
            //Assert.Equal("Hello!", result); 
            Assert.Equal(3, count);
        }
        string IncrementCount(string message)
        {
            count++;
            return message.ToLower();
        }
        string ReturnMessage(string message)
        {
            count++;
            return message;
        }
        [Fact]
        public void valueTypesAlsoPassByValue()
        {
            var x = GetInt();
            setInt(ref x);

            Assert.Equal(42, x);
        }

        private void setInt(ref Int32 z)
        {
            z = 42;
        }

        private int GetInt()
        {
            return 3;
        }
        [Fact]
        public void CSharbCanPassByRef()
        { 
           var book1 = GetBook("InMemoryBook 1");
            GetBookSetName(out book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }

        private void GetBookSetName(out InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }

        [Fact]
        public void CanSetNameFromReference()
        {
            var book1 = GetBook("InMemoryBook 1");
            SetName(book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }

        private void SetName(InMemoryBook book, string name)
        {
            book.Name = name;
        }

        [Fact]
        public void StringsBehaveLikeValueTypes()
        {
            string name = "";
           // var upper = MakeUpperCase(name);
        }
        [Fact]
        public void TestRefrencingDifferentObjects()
        {
            var book1 = GetBook("InMemoryBook 1");
            var book2 = GetBook("InMemoryBook 2");

            Assert.Equal("InMemoryBook 1", book1.Name);
            Assert.Equal("InMemoryBook 2", book2.Name);
        }

        [Fact]
        public void TWoVariablesRefrencingSameObject()
        {
            var book1 = GetBook("InMemoryBook 1");
            var book2 = book1;

            Assert.Same(book1, book2);
            Assert.True(object.ReferenceEquals(book1, book2));

            Assert.Equal("InMemoryBook 1", book1.Name);
            Assert.Equal("InMemoryBook 1", book2.Name);
        }

        InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name);
        }
    }
}
