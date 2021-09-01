using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] bounds = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            string evenOrOdd = Console.ReadLine();

            Predicate<int> type = GetType(evenOrOdd);

            List<int> number = Enumerable.Range(bounds[0], bounds[1] - bounds[0]+1).Where(n => type(n)).ToList();
            Action<List<int>> print = n => Console.WriteLine(string.Join(" ",n));

            print(number);
        }
        //TODO: TEST (judge not working)
        private static Predicate<int> GetType(string type)
        {
            Predicate<int> typeOfNumbers;
            if (type == "even")
            {
                return typeOfNumbers = n => n % 2 == 0;
            }
            else
            {
                return typeOfNumbers = n => n % 2 != 0;
            }
        }
        
    }
}
