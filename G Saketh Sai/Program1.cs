using System;
using System.Globalization;

namespace Program1.cs
{
    internal class Program1
    {
        static void Main(string[] args)
        {
            if (args.Length >= 3)
            {
                if (!TryParseDouble(args[0], out var a) || !TryParseDouble(args[1], out var b))
                {
                    Console.WriteLine("Invalid numeric inputs.");
                    return;
                }

                var operation = args[2];
                RunCalculationAndPrint(a, b, operation);
                return;
            }

            Console.Write("Enter value for a (double): ");
            if (!TryParseDouble(Console.ReadLine(), out var aInput))
            {
                Console.WriteLine("Invalid input for a.");
                return;
            }

            Console.Write("Enter value for b (double): ");
            if (!TryParseDouble(Console.ReadLine(), out var bInput))
            {
                Console.WriteLine("Invalid input for b.");
                return;
            }

            Console.Write("Enter operation (add, +, subtract, -, multiply, *, divide, /): ");
            var opInput = Console.ReadLine();

            RunCalculationAndPrint(aInput, bInput, opInput);
        }

        private static void RunCalculationAndPrint(double a, double b, string operation)
        {
            try
            {
                var result = Calculator.Calculate(a, b, operation);
                Console.WriteLine($"Result: {result}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private static bool TryParseDouble(string? s, out double value)
        {
            value = 0;
            if (string.IsNullOrWhiteSpace(s))
                return false;
            return double.TryParse(s, NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.InvariantCulture, out value);
        }
    }
    internal static class Calculator
    {
        public static double Calculate(double a, double b, string? operation)
        {
            if (operation is null)
                throw new ArgumentException("Operation must be provided.", nameof(operation));

            switch (operation.Trim().ToLowerInvariant())
            {
                case "add":
                case "addition":
                case "+":
                    return Add(a, b);

                case "subtract":
                case "sub":
                case "subtraction":
                case "-":
                    return Subtract(a, b);

                case "multiply":
                case "mul":
                case "multiplication":
                case "*":
                    return Multiply(a, b);

                case "divide":
                case "div":
                case "division":
                case "/":
                    return Divide(a, b);

                default:
                    throw new ArgumentException($"Unknown operation '{operation}'. Supported: add, subtract, multiply, divide (or +, -, *, /).");
            }
        }

        public static double Add(double a, double b) => a + b;

        public static double Subtract(double a, double b) => a - b;

        public static double Multiply(double a, double b) => a * b;

        public static double Divide(double a, double b)
        {
            if (b == 0.0)
                throw new DivideByZeroException("Cannot divide by zero.");
            return a / b;
        }
    }
}
