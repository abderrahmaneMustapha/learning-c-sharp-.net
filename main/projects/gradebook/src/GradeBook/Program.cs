using System;
using System.Collections.Generic;
namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Book book = new Book("abderrahmane");

            book.gradeAdded += onGradeAdded;
            
            while(true){
                System.Console.WriteLine(" enter exit to quite or enter a grade");
                var input = Console.ReadLine();
                if (input=="exit"){
                    break;
                }
                try {
                    var grade =  double.Parse(input);
                    book.addGrade(grade);
                }
                catch( ArgumentException ex){
                    System.Console.WriteLine(ex.Message);
                }   
                catch( FormatException ex){
                    System.Console.WriteLine(ex.Message);
                } 
                finally{
                    System.Console.WriteLine("__________________________");
                }           
              
            }

            

            int count = book.countGrades();
            var result = book.calculateResult();

            Console.WriteLine($"Book name :  {book.Name}");
            Console.WriteLine($"Number of grades {count}");
            Console.WriteLine($"Avgerage Letter {result.Letter}");

            book.result();
        
    

            
          
        }

        static void onGradeAdded(Object sender, EventArgs arg ){
            System.Console.WriteLine("A grade was added");
        }
    }
}
