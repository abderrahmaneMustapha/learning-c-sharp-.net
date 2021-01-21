using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void Test1()
        {
            Book book = new Book("abderrahmane");

            book.greeting();

            book.addGrade(1);
            book.addGrade(1);
            

            var result = book.calculateResult();
            System.Console.WriteLine(result.High); 
           
            Assert.Equal(1 ,result.Average);
            Assert.Equal(1 ,result.High);


        }
    }
}
