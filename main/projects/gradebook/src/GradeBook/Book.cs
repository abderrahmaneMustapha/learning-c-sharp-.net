using System.Collections.Generic;
namespace  GradeBook{
    class Book{
        public Book(string name ) {
            grades = new List<double>();
            this.name =  name;
        }
        public  void addGrade(double grade){
            grades.Add(grade);
        }

        public int countGrades(){
            return grades.Count;
        }
        public  void result(){
            System.Console.WriteLine($" {calculateResult()}");
        }
        public void greeting(){
             System.Console.WriteLine($"Hello {name}");
        }
        private double calculateResult(){
            double result=0.0;
            int count = countGrades();
            foreach( double grade in grades ){
                result += grade;
            }

            return result / count;
        }

        

        private List<double> grades;
        private string name;

    }
}