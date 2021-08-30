using System;
using System.Linq;
using System.Collections.Generic;

namespace _02.SetsOElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] lengthOfSets = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int totalLength = lengthOfSets[0] + lengthOfSets[1];

            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();

            for (int i = 0; i < totalLength; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (i<lengthOfSets[0])
                {
                    firstSet.Add(number);
                }
                else
                {
                    secondSet.Add(number);
                }
            }

            IEnumerable<int> commonElemts = firstSet.Intersect(secondSet);

            Console.WriteLine(string.Join(" ",commonElemts));
        }

    }
}
