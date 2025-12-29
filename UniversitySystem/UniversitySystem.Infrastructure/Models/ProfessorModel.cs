using System.Collections.Generic;

namespace UniversitySystem.Infrastructure.Models
{
    // Наслідує PersonModel (для Table-per-Type)
    public class ProfessorModel : PersonModel
    {
        public string Department { get; set; }
        public int ExperienceYears { get; set; }

        // 1:M зв'язок (Професор викладає багато CourseModel)
        public ICollection<CourseModel> TaughtCourses { get; set; } = new List<CourseModel>();
    }
}
