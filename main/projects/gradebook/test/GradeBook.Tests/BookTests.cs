using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
         [Fact]
        public void cantAddMorethen100LessThen0()
        {
            Book book = new Book("New book");

            book.greeting();

            book.addGrade(1);
            book.addGrade(1);
            int countBeforAddInvalideValue = book.countGrades();
            book.printGrades();

            book.addGrade(104);
            book.addGrade(590);
        
            int countAfterAddInvalideValue = book.countGrades();
            
            Assert.Equal(countAfterAddInvalideValue, countBeforAddInvalideValue);

           


        }

        [Fact]
        public void calculateResults()
        {
            Book book = new Book("abderrahmane");

            book.greeting();

            book.addGrade(1);
            book.addGrade(1);
            book.addGrade(104);
            

            var result = book.calculateResult();
            System.Console.WriteLine(result.High); 
           
            Assert.Equal(1 ,result.Average);
            Assert.Equal(1 ,result.High);
            Assert.Equal('F' ,result.Letter);

        }
    }
}
