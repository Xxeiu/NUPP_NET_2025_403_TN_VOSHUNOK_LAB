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
using UniversitySystem.Common;
using System.Diagnostics; 
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.IO;


await MainAsync();

async Task MainAsync()
{
    Console.WriteLine("=================================================");
    Console.WriteLine("=== Lab 2: Async, Parallelism, LINQ Demo ===");
    Console.WriteLine("=================================================");

    const int NumberOfStudents = 2000; 
    const string FilePath = "async_students.json";

    var studentService = new UniversityCrudServiceAsync<Student>();

 
    Console.WriteLine($"\n--- 1. Parallel Creation of {NumberOfStudents} Students ---");
    var stopwatch = Stopwatch.StartNew();

   
    Parallel.For(0, NumberOfStudents, async (i) =>
    {
        var student = Student.CreateNew();
        await studentService.CreateAsync(student); 
    });

    stopwatch.Stop();
    Console.WriteLine($"Створення завершено за: {stopwatch.ElapsedMilliseconds} мс");

    
    var count = (await studentService.ReadAllAsync()).Count();
    Console.WriteLine($"Фактично створено об'єктів: {count}");

    
    Console.WriteLine("\n--- 2. LINQ Aggregation (Min, Max, Avg) ---");
    var allStudents = await studentService.ReadAllAsync();

   
    var minGrade = allStudents.Min(s => s.AverageGrade);
    var maxGrade = allStudents.Max(s => s.AverageGrade);
    var avgGrade = allStudents.Average(s => s.AverageGrade);
    var minCourse = allStudents.Min(s => s.Course);
    var maxCourse = allStudents.Max(s => s.Course);
    var avgCourse = allStudents.Average(s => s.Course);

    Console.WriteLine($"Середній бал: {avgGrade:F2}");
    Console.WriteLine($"Мінімальний бал: {minGrade:F2}, Максимальний бал: {maxGrade:F2}");
    Console.WriteLine($"Середній курс: {avgCourse:F2}");
    Console.WriteLine($"Мінімальний курс: {minCourse}, Максимальний курс: {maxCourse}");


   
    Console.WriteLine("\n--- 3. Asynchronous Save ---");
    await studentService.SaveAsync(FilePath);

   
    Console.WriteLine("\n--- 4. Pagination (Page 2, 5 items) ---");
    var page2 = await studentService.ReadAllAsync(page: 2, amount: 5);

    foreach (var s in page2)
    {
        Console.WriteLine($"[PAGE 2] {s.ToFullName()}, Курс: {s.Course}");
    }

   
    Console.WriteLine("\n--- 5. Synchronization Primitive: AutoResetEvent Demo ---");

    var autoEvent = new AutoResetEvent(initialState: false);
    var demoThread = new Thread(() =>
    {
        Console.WriteLine("[Thread] Очікування сигналу...");
        autoEvent.WaitOne(); 
        Console.WriteLine("[Thread] Сигнал отримано! Продовження роботи...");
    });

    demoThread.Start();

    Thread.Sleep(100); 
    Console.WriteLine("[Main] Надсилання сигналу...");
    autoEvent.Set();

    demoThread.Join();
    Console.WriteLine("[Main] Демонстрація AutoResetEvent завершена.");

  
    if (File.Exists(FilePath))
    {
        File.Delete(FilePath);
    }
}
