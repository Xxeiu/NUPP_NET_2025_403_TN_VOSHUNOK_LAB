namespace UniversitySystem.Infrastructure.Models
{
    // Сутність для реалізації зв'язку Багато-до-Багатьох
    public class StudentCourseModel
    {
        // Зовнішні ключі, які формують складений ключ
        public int StudentId { get; set; }
        public StudentModel Student { get; set; }

        public int CourseId { get; set; }
        public CourseModel Course { get; set; }
    }
}
