using System.Collections.Generic;

namespace UniversitySystem.Infrastructure.Models
{
    public class CourseModel
    {
        public int Id { get; set; }
        public string Title { get; set; } 
        public int Credits { get; set; } 

        // Властивості для 1:M зв'язку:
        public int ProfessorId { get; set; } // Зовнішній ключ
        public ProfessorModel Lecturer { get; set; } // Навігаційна властивість

        // Навігаційна властивість для M:M зв'язку
        public ICollection<StudentCourseModel> StudentCourses { get; set; } = new List<StudentCourseModel>();
    }
}
