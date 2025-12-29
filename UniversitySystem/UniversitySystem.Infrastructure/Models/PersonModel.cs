using System;
using System.ComponentModel.DataAnnotations;

namespace UniversitySystem.Infrastructure.Models
{
    // Базовий клас для наслідування (Table-per-Type)
    public abstract class PersonModel
    {
        [Key] // Анотація, що вказує на первинний ключ таблиці
        public int Id { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
