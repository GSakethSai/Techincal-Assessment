using System;
using System.Collections.Generic;

namespace Assessment
{
    internal class Program2
    {
        static void Main(string[] args)
        {
            int a = 0;
            if (args.Length >= 1 && int.TryParse(args[0], out a) == false)
            {
                Console.WriteLine("Invalid command-line argument. Please provide a whole number.");
                return;
            }

            if (args.Length == 0)
            {
                Console.Write("Enter a single integer (a): ");
                var input = Console.ReadLine();
                if (!int.TryParse(input, out a))
                {
                    Console.WriteLine("Invalid input. Please enter a whole number.");
                    return;
                }
            }

            if (a <= 0)
            {
                Console.WriteLine("Please enter a positive integer greater than zero.");
                return;
            }

            var series = GenerateOddSeries(a);
            Console.WriteLine(string.Join(", ", series));
        }

        // For input 'a' produce: if 'a' is odd -> first 'a' odd numbers;
        // if 'a' is even -> first (a - 1) odd numbers.
        private static IEnumerable<int> GenerateOddSeries(int a)
        {
            int count = (a % 2 == 0) ? a - 1 : a;
            for (int i = 0; i < count; i++)
            {
                yield return 2 * i + 1;
            }
        }
    }
}
