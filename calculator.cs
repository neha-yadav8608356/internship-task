using System;

namespace MyCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("--- Automatic Calculator Task (Day 6) ---");
            Console.WriteLine("Testing all operations automatically...\n");

            double a = 10;
            double b = 5;
            double zero = 0;

            Console.WriteLine($"Addition: {a} + {b} = {a + b}");
            Console.WriteLine($"Subtraction: {a} - {b} = {a - b}");
            Console.WriteLine($"Multiplication: {a} * {b} = {a * b}");

            Console.WriteLine($"Advanced: Modulus (10 % 3) = {10 % 3}");
            Console.WriteLine($"Advanced: Power (2 ^ 3) = {Math.Pow(2, 3)}");

            Console.WriteLine("\n--- Error Handling Check ---");
            if (zero == 0)
            {
                Console.WriteLine("Error Check: 10 / 0 is NOT allowed! (DivideByZero handled)");
            }
            else
            {
                Console.WriteLine($"Division: 10 / 5 = {10 / 5}");
            }

        }
    }
}