using System;
using System.Collections.Generic;
using System.Linq;

namespace Assessment
{
    internal class Program4
    {
        static void Main(string[] args)
        {
            string? rawInput = null;
            if (args.Length >= 1)
            {
                rawInput = args[0];
            }
            else
            {
                Console.Write("Enter integers separated by commas or spaces (e.g. 1,2,8,9,12,...): ");
                rawInput = Console.ReadLine();
            }

            if (string.IsNullOrWhiteSpace(rawInput))
            {
                Console.WriteLine("No input provided.");
                return;
            }

            var numbers = ParseNumbers(rawInput);
            if (numbers.Count == 0)
            {
                Console.WriteLine("No valid integers parsed from input.");
                return;
            }

            var counts = GetMultiplesCount(numbers);

            var formatted = string.Join(", ", counts.Select(kvp => $"{kvp.Key}: {kvp.Value}"));
            Console.WriteLine("{" + formatted + "}");
        }

        private static List<int> ParseNumbers(string input)
        {
            var seps = new[] { ',', ';', ' ', '\t' };
            return input
                .Split(seps, StringSplitOptions.RemoveEmptyEntries)
                .Select(s =>
                {
                    if (int.TryParse(s.Trim(), out var v))
                        return (ok: true, value: v);
                    return (ok: false, value: 0);
                })
                .Where(x => x.ok)
                .Select(x => x.value)
                .ToList();
        }

        private static IDictionary<int, int> GetMultiplesCount(IReadOnlyList<int> numbers)
        {
            return Enumerable.Range(1, 9)
                .ToDictionary(k => k, k => numbers.Count(n => n % k == 0));
        }
    }
    }
