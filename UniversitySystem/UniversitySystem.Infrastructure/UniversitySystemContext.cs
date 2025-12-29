using Microsoft.EntityFrameworkCore;
using UniversitySystem.Infrastructure.Models;

namespace UniversitySystem.Infrastructure
{
    
    public class UniversitySystemContext : DbContext
    {
        
        public DbSet<PersonModel> People { get; set; }
        public DbSet<StudentModel> Students { get; set; }
        public DbSet<ProfessorModel> Professors { get; set; }
        public DbSet<CourseModel> Courses { get; set; }
        public DbSet<StudentDetailsModel> StudentDetails { get; set; }
        public DbSet<StudentCourseModel> StudentCourses { get; set; }

        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            optionsBuilder.UseSqlite("Data Source=university.db"); 
        }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<PersonModel>().ToTable("People");
            modelBuilder.Entity<StudentModel>().ToTable("Students");
            modelBuilder.Entity<ProfessorModel>().ToTable("Professors");

            
            modelBuilder.Entity<StudentModel>()
                .HasOne(s => s.Details) 
                .WithOne(d => d.Student) 
                .HasForeignKey<StudentDetailsModel>(d => d.StudentId); 
           
            modelBuilder.Entity<CourseModel>()
                .HasOne(c => c.Lecturer) 
                .WithMany(p => p.TaughtCourses) 
                .HasForeignKey(c => c.ProfessorId); 
           
            modelBuilder.Entity<StudentCourseModel>()
                .HasKey(sc => new { sc.StudentId, sc.CourseId }); 

            
            modelBuilder.Entity<StudentCourseModel>()
                .HasOne(sc => sc.Student)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(sc => sc.StudentId);

            modelBuilder.Entity<StudentCourseModel>()
                .HasOne(sc => sc.Course)
                .WithMany(c => c.StudentCourses)
                .HasForeignKey(sc => sc.CourseId);
        }
    }
}
