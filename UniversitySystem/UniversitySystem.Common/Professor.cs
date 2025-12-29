using System;

namespace UniversitySystem.Common
{
    // Похідний клас Professor, який наслідує Person. Друге наслідування (Завдання 1)
    public class Professor
    {
        // Статичне поле (Завдання 2)
        public static readonly string UniversityName; 

        // Властивість 1
        public string Department { get; set; }

        // Властивість 2
        public string ScientificDegree { get; set; }

        // Властивість 3
        public int ExperienceYears { get; set; }


        // Статичний конструктор (Завдання 2)
        // Викликається лише один раз, коли клас Professor завантажується середовищем CLR
        static Professor()
        {
            UniversityName = "National University of Poltava";
            Console.WriteLine($"[INFO] Static constructor executed. University: {UniversityName}");
        }

        // Звичайний конструктор (Завдання 2)
        public Professor(string firstName, string lastName) 
        {
            Department = "General";
            ScientificDegree = "Candidate of Sciences";
        }

        // Делегат (Завдання 2)
        public delegate void LectureStartedEventHandler(string topic);

        // Подія (Завдання 2)
        public event LectureStartedEventHandler LectureStarted;

        // Метод, який викликає подію
        public void StartLecture(string topic)
        {
            Console.WriteLine($"Professor {LastName} starts lecture on: {topic}");
            // Виклик події
            LectureStarted?.Invoke(topic);
        }

        // Статичний метод (Завдання 2)
        public static void ShowUniversityInfo()
        {
            Console.WriteLine($"Professor class static method: Institution is {UniversityName}");
        }
    }
}
