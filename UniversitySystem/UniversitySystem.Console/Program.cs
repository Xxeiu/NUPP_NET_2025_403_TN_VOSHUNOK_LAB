using UniversitySystem.Common;

Console.WriteLine("=================================================");
Console.WriteLine("=== University System Console Demonstration ===");
Console.WriteLine("=================================================");


var studentService = new UniversityCrudService<Student>();
Console.WriteLine("\n--- CRUD Service initialized for Students ---");


var student1 = new Student("Іван", "Петренко", 2) { AverageGrade = 4.5 };
var student2 = new Student("Олена", "Коваль", 3) { AverageGrade = 4.9 };


studentService.Create(student1);
studentService.Create(student2);

Console.WriteLine("\n--- 2. Read All: Список студентів після додавання ---");

foreach (var s in studentService.ReadAll())
{
    
    Console.WriteLine($"[READ] ID: {s.Id}, Ім'я: {s.ToFullName()}, Курс: {s.Course}, Середній бал: {s.AverageGrade}");
}


var ivanId = student1.Id;
var readIvan = studentService.Read(ivanId);
Console.WriteLine($"\n--- 3. Read: Знайдений студент (ID: {ivanId}) ---");
Console.WriteLine($"Студент: {readIvan.ToFullName()}, Курс: {readIvan.Course}");


readIvan.Course = 4;
readIvan.Study(); 
studentService.Update(readIvan);
Console.WriteLine($"\n--- 4. Update: Іван переведено на {studentService.Read(ivanId).Course} курс ---");


studentService.Remove(student2);

Console.WriteLine("\n--- 5. Read All: Список студентів після оновлення та видалення ---");
foreach (var s in studentService.ReadAll())
{
    Console.WriteLine($"[FINAL] ID: {s.Id}, Ім'я: {s.ToFullName()}, Курс: {s.Course}");
}


Console.WriteLine("\n=================================================");
Console.WriteLine("=== ООП та Базові Конструкції Демонстрація ===");
Console.WriteLine("=================================================");

var prof = new Professor("Марія", "Іваненко");

prof.LectureStarted += (topic) => 
{
    Console.WriteLine($"[ПОДІЯ АКТИВОВАНА]: Оповіщення: Викладач розпочав лекцію про {topic}.");
};

prof.StartLecture("C# Generics"); 


Professor.ShowUniversityInfo(); 

Console.WriteLine($"\nУніверситет (Статичне поле): {Professor.UniversityName}"); 
Console.WriteLine("=================================================\n");
