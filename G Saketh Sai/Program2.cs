using System;
using System.Collections.Generic;

namespace Assessment
{
    internal class Program2
    {
        static void Main(string[] args)
        {
            int count = 0;
            if (args.Length >= 1 && int.TryParse(args[0], out count) == false)
            {
                Console.WriteLine("Invalid command-line argument. Please provide a whole number.");
                return;
            }

            if (args.Length == 0)
            {
                Console.Write("Enter a single integer (count of odd numbers to generate): ");
                var input = Console.ReadLine();
                if (!int.TryParse(input, out count))
                {
                    Console.WriteLine("Invalid input. Please enter a whole number.");
                    return;
                }
            }

            if (count <= 0)
            {
                Console.WriteLine("Please enter a positive integer greater than zero.");
                return;
            }

            var series = GenerateOddSeries(count);
            Console.WriteLine(string.Join(", ", series));
        }

        private static IEnumerable<int> GenerateOddSeries(int count)
        {
            for (int i = 0; i < count; i++)
            {
                yield return 2 * i + 1;
            }


        }
    }
}
