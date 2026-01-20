using System;
using System.Collections.Generic;
using System.Linq;

namespace UtilityLibrary
{
    public static class UtilityExtensions
    {
        /// <summary>
        /// Name formatting: Pehla akshar Capital aur baaki small karta hai.
        /// </summary>
        public static string ToTitleCase(this string str)
        {
            if (string.IsNullOrWhiteSpace(str)) return str;
            return char.ToUpper(str[0]) + str.Substring(1).ToLower();
        }

        /// <summary>
        /// Check karta hai ki marks 0 aur 100 ke range mein hain ya nahi.
        /// </summary>
        public static bool IsValidMark(this int mark)
        {
            return mark >= 0 && mark <= 100;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Day 9: Final Documented Utility Library ---");

            Console.Write("Student ka naam: ");
            string name = (Console.ReadLine() ?? "").ToTitleCase();

            List<int> marks = GetValidatedMarks();
            
            if (marks.Any())
            {
                double avg = marks.Average();
                int highest = marks.Max();

                Console.WriteLine($"\n--- FINAL REPORT FOR: {name} ---");
                Console.WriteLine($"Average Marks: {avg:F2}");
                Console.WriteLine($"Highest Mark: {highest}");
                Console.WriteLine($"Status: {GetGradeStatus(avg)}");

                int subjectCount = marks.Count;
                Console.WriteLine($"\n--- Late Afternoon: Recursion Demo ---");
                Console.WriteLine($"Factorial of subject count ({subjectCount}!): {GetFactorial(subjectCount)}");
            }
        }

        /// <summary>
        /// User se 3 subjects ke marks input leta hai aur error handling karta hai.
        /// </summary>
        static List<int> GetValidatedMarks()
        {
            List<int> marksList = new List<int>();
            for (int i = 1; i <= 3; i++)
            {
                Console.Write($"Subject {i} marks (0-100): ");
                string input = Console.ReadLine() ?? "";
                
                if (int.TryParse(input, out int m) && m.IsValidMark())
                {
                    marksList.Add(m);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("❌ Invalid Input! Enter a number between 0-100.");
                    Console.ResetColor();
                    i--; 
                }
            }
            return marksList;
        }

        /// <summary>
        /// Average marks ke basis par Pass ya Fail status return karta hai.
        /// </summary>
        static string GetGradeStatus(double average)
        {
            return average >= 40 ? "Pass ✅" : "Fail ❌";
        }

        /// <summary>
        /// Recursive method jo mathematical factorial (!) calculate karta hai.
        /// </summary>
        static int GetFactorial(int n)
        {
            if (n <= 1) return 1;
            return n * GetFactorial(n - 1);
        }
    }
}