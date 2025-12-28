using System;

namespace UniversitySystem.Common
{
    
    public class Professor : Person
    {
    
        public static readonly string UniversityName; 

        public string Department { get; set; }

        
        public string ScientificDegree { get; set; }

        
        public int ExperienceYears { get; set; }


       
        static Professor()
        {
            UniversityName = "National University of Poltava";
            Console.WriteLine($"[INFO] Static constructor executed. University: {UniversityName}");
        }

       
        public Professor(string firstName, string lastName) : base(firstName, lastName)
        {
            Department = "General";
            ScientificDegree = "Candidate of Sciences";
        }

        
        public delegate void LectureStartedEventHandler(string topic);

      
        public event LectureStartedEventHandler LectureStarted;

        public void StartLecture(string topic)
        {
            Console.WriteLine($"Professor {LastName} starts lecture on: {topic}");
           
            LectureStarted?.Invoke(topic);
        }


        public static void ShowUniversityInfo()
        {
            Console.WriteLine($"Professor class static method: Institution is {UniversityName}");
        }
    }
}
using System;
using System.Collections.Generic;

namespace UniversitySystem.Common
{
    public class Professor : Person
    {
        
        private static readonly Random Rnd = new Random();
        private static readonly string[] Degrees = { "Ph.D.", "D.Sc.", "Assoc. Prof." };

        public static Professor CreateNew()
        {
            return new Professor(
                firstName: $"Prof_FN_{Rnd.Next(1, 100)}",
                lastName: $"Prof_LN_{Rnd.Next(1, 100)}"
            )
            {
                Department = "Computer Science",
                ScientificDegree = Degrees[Rnd.Next(Degrees.Length)],
                ExperienceYears = Rnd.Next(5, 30)
            };
        }
    }
}
