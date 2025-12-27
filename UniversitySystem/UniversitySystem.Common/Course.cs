using System;

namespace UniversitySystem.Common
{
    // Четвертий незалежний клас (Виконання вимоги 4+ класів)
    public class Course
    {
        public Guid Id { get; set; }
        public string Title { get; set; } // Властивість 1
        public int Credits { get; set; } // Властивість 2
        public Professor Lecturer { get; set; } // Властивість 3 (композиція/агрегація)

        // Конструктор за замовчуванням
        public Course()
        {
            Id = Guid.NewGuid();
        }

        // Метод
        public string GetCourseInfo()
        {
            return $"Курс: {Title}, Кредити: {Credits}, Викладач: {Lecturer.LastName}";
        }
    }
}
