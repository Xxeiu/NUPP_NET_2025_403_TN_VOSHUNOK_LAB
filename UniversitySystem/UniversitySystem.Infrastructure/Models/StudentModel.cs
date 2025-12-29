using System.Collections.Generic;

namespace UniversitySystem.Infrastructure.Models
{
    // Наслідує PersonModel (для Table-per-Type)
    public class StudentModel : PersonModel
    {
        public int CourseNumber { get; set; } 
        public double AverageGrade { get; set; }

        // Навігаційні властивості для зв'язків:

        // 1:1 зв'язок
        public StudentDetailsModel Details { get; set; } 

        // M:M зв'язок (колекція проміжних об'єктів)
        public ICollection<StudentCourseModel> StudentCourses { get; set; } = new List<StudentCourseModel>();
    }
}
