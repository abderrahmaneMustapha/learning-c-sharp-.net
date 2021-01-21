using System;
using System.Collections.Generic;
namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            /* a one way to declare an array in c sharp
            var  vars =  new[] {3, 4, 4, 4};
            */
            Book book = new Book("abderrahmane");

            book.greeting();

            book.addGrade(34);
            book.addGrade(34.45);
            book.addGrade(10.4);

            int count = book.countGrades();
            Console.WriteLine($"Number of grades {count}");

            book.result();
        
    

            
          
        }
    }
}
