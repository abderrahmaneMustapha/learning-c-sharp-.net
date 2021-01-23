using System.Collections.Generic;
using System;
namespace  GradeBook{
    public delegate void gradeAddedDelegate(Object sender, EventArgs args);
    public class Book{

        
        public Book(string name ) {
            grades = new List<double>();
            this.name =  name;
        }
        public  void addGrade(double grade){
            if( grade <= 100 && grade >= 0){
                grades.Add(grade);
                if (gradeAdded != null){
                    gradeAdded(this, new EventArgs());
                }
            }
            else{
               throw new ArgumentException($"Invalid {nameof(grade)}");
            }
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

        public event gradeAddedDelegate gradeAdded;
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

            switch(result.Average){
                case var d when d >= 90.0:
                    result.Letter = 'A';
                    break;
                case var d when d >= 80.0:
                    result.Letter = 'B';
                    break;
                case var d when d >= 70.0:
                    result.Letter = 'C';
                    break;
                case var d when d >= 60.0:
                    result.Letter = 'D';
                    break;
                default:
                    result.Letter = 'F';
                    break;
            }
            return result;
        }
        
        public void printGrades(){
            foreach( int grade in grades ){
                System.Console.WriteLine($" grade  : {grade}");
            }
        }
        

        private List<double> grades;

        public string Name{
            get{
                return name;
            }

            set {
                if (!String.IsNullOrEmpty(value)){
                    name =  value;
                }
            }
        }
        private string name;

    }
}