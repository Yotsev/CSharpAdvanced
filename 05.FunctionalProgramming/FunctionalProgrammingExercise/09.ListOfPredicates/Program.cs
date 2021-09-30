using System;
using System.Linq;

namespace _09.ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int rangeEnd = int.Parse(Console.ReadLine());
            int[] dividers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] range = Enumerable.Range(1, rangeEnd).ToArray();

            Func<int, int, bool> predicate = (number, divider) => number % divider == 0;

            foreach (var number in range)
            {
                if (dividers.All(d => predicate(number, d)))
                {
                    Console.Write($"{number} ");
                }
            }
        }
    }
}
