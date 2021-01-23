using System;
using Xunit;

namespace GradeBook.Tests
{
    public delegate string writeLogDelegate(string LogMessage);
    public class TypeTest
    {   
        int count = 0;
        [Fact]
        public void writeLogDelegateCanPointToMethod(){
            writeLogDelegate logDelegate = returnMessage;
            logDelegate += returnMessage;
            logDelegate += incrementMessage;

            var result =  logDelegate("Hello guys ....");

            Assert.Equal(3, count);

        }

        string incrementMessage(string message){
            count++;
            return message;
        }

        string returnMessage(string message){
            count++;
            return message;
        }

        [Fact]
        public void StringBehaveLikeValueTypes(){
            string name = "abderrahmane";
            string upper  = makeUpperCase(name);

            Assert.Equal("ABDERRAHMANE", upper);
        }

        private string makeUpperCase(string name)
        {
            return name.ToUpper();
        }

        [Fact]
        public void valueTypeAlsoPassByVlaue()
        {
            int  x =  1;
            setInt(ref x);

            Assert.Equal(33, x);
          
        }

        private void setInt(ref int z)
        {
            z = 33;
        }
        
         [Fact]
        public void cSharpIsPassByValue()
        {
            var  book1 =  GetBook("book1");
            getBookSetName(book1, "Pragmattic");

            Assert.Equal("book1", book1.Name);
          
        }

        private void getBookSetName(Book book, string name)
        {
            book = new Book(name)  ;
        }
         [Fact]
        public void canSetNameFromReference()
        {
            var  book1 =  GetBook("book1");
            setName(book1, "Pragmattic");

            Assert.Equal("Pragmattic", book1.Name);
          
        }

        private void setName(Book book, string name)
        {
             book.Name = name;
        }

        [Fact]
        public void getBookReturnDifferentObjects()
        {
            var  book1 =  GetBook("book1");
            var  book2 =  GetBook("book2");

            Assert.Equal("book1", book1.Name);
            Assert.Equal("book2", book2.Name);

            Assert.NotSame(book1, book2);
        }
        [Fact]
          public void getBookReturnSameObjects()
        {
            var  book1 =  GetBook("book1");
            var  book2 =  book1;

            Assert.Same(book1, book2);
        }

        Book GetBook(string name){
            return new Book(name);
        }
    }
}
