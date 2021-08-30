using System;
using System.Collections.Generic;

namespace _05.CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            SortedDictionary<char, int> occurrences = new SortedDictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (! occurrences.ContainsKey(input[i]))
                {
                    occurrences.Add(input[i], 0);
                }
                occurrences[input[i]]++;
            }

            foreach (var item in occurrences)
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}
