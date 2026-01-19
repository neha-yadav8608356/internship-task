using System;
using System.Collections.Generic;
using System.Linq;

// Task: Data Structure Optimization (User se input lena)
var students = new List<(string Name, int Grade)>();

Console.WriteLine("--- Day 8: Advanced Student Manager ---");
Console.Write("Kitne students ka data enter karna hai? ");

if (int.TryParse(Console.ReadLine(), out int count))
{
    for (int i = 1; i <= count; i++)
    {
        Console.Write($"\nStudent {i} ka naam: ");
        string name = Console.ReadLine() ?? "Unknown";

        Console.Write($"{name} ke marks (0-100): ");
        if (int.TryParse(Console.ReadLine(), out int grade))
        {
            students.Add((name, grade));
        }
        else
        {
            Console.WriteLine("Galat marks! Ise skip kiya ja raha hai.");
        }
    }
}

// Filtering Logic
Console.WriteLine("\nKaunsa report dekhna hai? 1. Sabhi 2. Pass 3. Fail");
string choice = Console.ReadLine() ?? "";

var filtered = choice switch
{
    "2" => students.Where(s => s.Grade >= 40),
    "3" => students.Where(s => s.Grade < 40),
    _ => students
};

// Data Visualization (Table Format)
Console.WriteLine("\n--- FINAL REPORT CARD ---");
Console.WriteLine("-------------------------------------------");
Console.WriteLine("| Name       | Grade | Status             |");
Console.WriteLine("-------------------------------------------");

foreach (var student in filtered)
{
    string status = student.Grade >= 40 ? "✅ PASS" : "❌ FAIL";
    Console.WriteLine($"| {student.Name,-10} | {student.Grade,-5} | {status,-18} |");
}
Console.WriteLine("-------------------------------------------");


// Mid Afternoon - Share LINQ Techniques ---

if (students.Any()) 
{
    // 1. Sorting: Highest marks wale student ko sabse upar dikhane ke liye
    var topStudent = students.OrderByDescending(s => s.Grade).First();

    // 2. Calculation: Pure class ka average marks nikalne ke liye
    double averageGrade = students.Average(s => s.Grade);

    Console.WriteLine("\n--- CLASS INSIGHTS (LINQ) ---");
    Console.WriteLine($"Average Class Grade: {averageGrade:F2}");
    Console.WriteLine($"Class Topper: {topStudent.Name} with {topStudent.Grade} marks");
    
    // 3. Count: Kitne students ne test diya
    Console.WriteLine($"Total Students Evaluated: {students.Count}");
}
