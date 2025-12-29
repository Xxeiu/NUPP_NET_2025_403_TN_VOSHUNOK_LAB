using System;

namespace UniversitySystem.Common
{
    // Похідний клас Student, який наслідує Person. Виконання вимоги про наслідування (Завдання 1)
    public class Student
    {
        // Властивість 1
        public string StudentId { get; set; }

        // Властивість 2
        public int Course { get; set; } 

        // Властивість 3
        public double AverageGrade { get; set; }

        // Конструктор за замовчуванням (Завдання 2)
        public Student() : base()
        {
            // Логіка ініціалізації
            StudentId = $"S-{new Random().Next(1000, 9999)}";
        }

        // Конструктор з параметрами (Завдання 2)
        public Student(string firstName, string lastName, int course) 
            
        {
            Course = course;
        }

        // Метод (Завдання 2)
        public void Study()
        {
            Console.WriteLine($"{FirstName} {LastName} (Курс {Course}) активно навчається.");
        }
    }
}
