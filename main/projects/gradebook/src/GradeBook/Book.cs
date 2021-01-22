using System.Collections.Generic;
using System;
namespace  GradeBook{
    public class Book{
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
            System.Console.WriteLine($" average {calculateResult().Average}");
        }
        public void greeting(){
             System.Console.WriteLine($"Hello {name}");
        }
        public  Statistics calculateResult(){
            var result = new Statistics();
            double average  = 0.0;
            var highGrade = double.MaxValue;
            var lowGrade =  double.MinValue;
            int count = countGrades();
            foreach( double grade in grades ){
                average += grade;
                lowGrade = Math.Min(grade, lowGrade);
                highGrade = Math.Min(grade,  highGrade);
            };

            average /= count;
            
            result.Average = average;
            result.High = highGrade;
            result.Low = lowGrade;
            return result;
        }

        

        private List<double> grades;
        public string name;

    }
}