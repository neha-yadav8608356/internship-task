using System;

namespace MyCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("--- Calculator Task ---");

            try
            {
                Console.Write("Enter first number: ");
                double a = double.Parse(Console.ReadLine());

                Console.Write("Enter second number: ");
                double b = double.Parse(Console.ReadLine());

                Console.WriteLine("\n--- Results ---");
                Console.WriteLine($"Addition: {a + b}");
                Console.WriteLine($"Subtraction: {a - b}");
                Console.WriteLine($"Multiplication: {a * b}");

                if (b == 0)
                {
                    Console.WriteLine("Division: Error! Cannot divide by zero.");
                }
                else
                {
                    Console.WriteLine($"Division: {a / b}");
                }

                Console.WriteLine($"Modulus: {a % b}");
                Console.WriteLine($"Power: {Math.Pow(a, b)}");
                Console.WriteLine($"Square Root: {Math.Sqrt(a)}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }

            Console.WriteLine("\n-------------------------");
            Console.ReadKey();
        }
    }
}