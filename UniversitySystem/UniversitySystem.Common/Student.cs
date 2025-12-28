using System;

namespace UniversitySystem.Common
{
    
    public class Student : Person
    {
       
        public string StudentId { get; set; }

       
        public int Course { get; set; } 

        
        public double AverageGrade { get; set; }

       
        public Student() : base()
        {
           
            StudentId = $"S-{new Random().Next(1000, 9999)}";
        }

        
        public Student(string firstName, string lastName, int course) 
            : base(firstName, lastName) 
        {
            Course = course;
        }

        
        public void Study()
        {
            Console.WriteLine($"{FirstName} {LastName} (Курс {Course}) активно навчається.");
        }
    }
}
using System;
using System.Collections.Generic; 
namespace UniversitySystem.Common
{
    public class Student : Person
    {
       

        
        private static readonly Random Rnd = new Random();

        public static Student CreateNew()
        {
            return new Student(
                firstName: $"Student_FN_{Rnd.Next(1, 1000)}",
                lastName: $"Student_LN_{Rnd.Next(1, 1000)}",
                course: Rnd.Next(1, 6)
            )
            {
                StudentId = $"S-{Guid.NewGuid().ToString().Substring(0, 4)}",
                AverageGrade = Math.Round(Rnd.NextDouble() * 2 + 3, 2) 
            };
        }
    }
}
