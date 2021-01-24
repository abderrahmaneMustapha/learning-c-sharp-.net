using System;
using System.Collections.Generic;
namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {

            DiskBook book = new  DiskBook("abderrahmane");

            book.gradeAdded += onGradeAdded;

            addGrades(book);

      

            Console.WriteLine($"Book name :  {book.Name}");

        

        }

        private static void addGrades(IBook book)
        {
            while (true)
            {
                System.Console.WriteLine(" enter exit to quite or enter a grade");
                var input = Console.ReadLine();
                if (input == "exit")
                {
                    break;
                }
                try
                {
                    var grade = double.Parse(input);
                    book.addGrade(grade);
                }
                catch (ArgumentException ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
                finally
                {
                    System.Console.WriteLine("__________________________");
                }

            }
        }

        static void onGradeAdded(Object sender, EventArgs arg ){
            System.Console.WriteLine("A grade was added");
        }
    }
}
