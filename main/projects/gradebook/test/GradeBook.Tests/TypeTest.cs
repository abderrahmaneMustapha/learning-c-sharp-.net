using System;
using Xunit;

namespace GradeBook.Tests
{
    public class TypeTest
    {   

         [Fact]
        public void cSharpIsPassByRef()
        {
            var  book1 =  GetBook("book1");
            getBookSetName(ref book1, "Pragmattic");

            Assert.Equal("Pragmattic", book1.name);
          
        }

        private void getBookSetName(ref Book book, string name)
        {
            book = new Book(name)  ;
        }
        
         [Fact]
        public void cSharpIsPassByValue()
        {
            var  book1 =  GetBook("book1");
            getBookSetName(book1, "Pragmattic");

            Assert.Equal("book1", book1.name);
          
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

            Assert.Equal("Pragmattic", book1.name);
          
        }

        private void setName(Book book, string name)
        {
             book.name = name;
        }

        [Fact]
        public void getBookReturnDifferentObjects()
        {
            var  book1 =  GetBook("book1");
            var  book2 =  GetBook("book2");

            Assert.Equal("book1", book1.name);
            Assert.Equal("book2", book2.name);

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
