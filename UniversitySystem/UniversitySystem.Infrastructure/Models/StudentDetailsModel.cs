using System;

namespace UniversitySystem.Infrastructure.Models
{
    // Сутність для демонстрації зв'язку 1:1
    public class StudentDetailsModel
    {
        public int Id { get; set; }
        public string RegistrationNumber { get; set; }
        public DateTime EnrollmentDate { get; set; }

        // Навігаційні властивості для зв'язку з StudentModel
        public int StudentId { get; set; } // Зовнішній ключ, вказує на Student
        public StudentModel Student { get; set; } 
    }
}
