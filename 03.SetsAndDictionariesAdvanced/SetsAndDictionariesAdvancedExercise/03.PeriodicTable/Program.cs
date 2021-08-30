using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfElements = int.Parse(Console.ReadLine());

            SortedSet<string> uniqueElements = new SortedSet<string>();

            for (int i = 0; i < numberOfElements; i++)
            {
                string[] elemets = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                foreach (string element in elemets)
                {
                    uniqueElements.Add(element);
                }
            }

            Console.WriteLine(string.Join(" ",uniqueElements));
        }
    }
}
