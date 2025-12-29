using System;

namespace UniversitySystem.Common
{
    // Базовий клас для доменних об'єктів (Student, Professor)
    public abstract class Person
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Конструктор
        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
