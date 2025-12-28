using System;

namespace UniversitySystem.Common
{
    // Похідний клас Student, який наслідує Person. Виконання вимоги про наслідування (Завдання 1)
    public class Student : Person
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
            : base(firstName, lastName) // Виклик конструктора базового класу
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
using System;
using System.Collections.Generic; // Якщо ще не додано

namespace UniversitySystem.Common
{
    public class Student : Person
    {
        // ... (існуючі властивості та конструктори)

        // Статичний метод для створення нового об'єкта зі згенерованими даними (Завдання 2)
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
                AverageGrade = Math.Round(Rnd.NextDouble() * 2 + 3, 2) // Оцінка від 3.00 до 5.00
            };
        }
    }
}
