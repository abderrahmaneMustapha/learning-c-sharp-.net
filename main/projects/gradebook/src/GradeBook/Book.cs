using System.Collections.Generic;
using System;
using System.IO;
namespace  GradeBook{
    public delegate void gradeAddedDelegate(Object sender, EventArgs args);
    
    public class NamedObject
    {
        public NamedObject(string name)
        {
            Name = name;
        }

        public string Name
        {
            get;
            set;
        }
    }

    public interface IBook{
        void addGrade(double grade);
        Statistics GetStatistics();
        string name {get;}
        event gradeAddedDelegate gradeAdded;
    }

    public abstract class Book : NamedObject, IBook
    {
        protected Book(string name) : base(name)
        {
        }

        public string name => throw new NotImplementedException();

        public abstract event gradeAddedDelegate gradeAdded;

        public abstract void addGrade(double grade);

        public abstract Statistics GetStatistics();
    }

    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {

        }

        public override event gradeAddedDelegate gradeAdded;

        public override void addGrade(double grade)
        {
            using(var writer  = File.AppendText($"{Name}.txt")){
                 writer.WriteLine(grade);
                 if (gradeAdded != null){
                     gradeAdded(this, new EventArgs());
                 }
            }
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override Statistics GetStatistics()
        {
          var result = new Statistics();
           using(var reader  = File.OpenText($"{Name}.txt")){
               var line = reader.ReadLine();
               while( line != null){
                   var number = double.Parse(line);
                   result.Add(number);
                   line = reader.ReadLine();
               }
               
           }
           return result;
            
        }

        public override string ToString()
        {
            return base.ToString();
        }
        private List<double> grades;
    }
    public class InMemmoryBook : Book{

        
        public InMemmoryBook(string name ):base(name) {
            grades = new List<double>();
            Name = name;
        }
        public override void addGrade(double grade){
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
        

        public override event gradeAddedDelegate gradeAdded;

        public  Statistics calculateResult(){
            var result = new Statistics();
           
            foreach( double grade in grades ){
                  result.Add(grade);
               
            };
            return result;
        }
        
        public void printGrades(){
            foreach( int grade in grades ){
                System.Console.WriteLine($" grade  : {grade}");
            }
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override Statistics GetStatistics()
        {
            throw new NotImplementedException();
        }

        private List<double> grades;

        

    }
}