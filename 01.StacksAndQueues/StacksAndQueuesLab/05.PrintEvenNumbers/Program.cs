using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.PrintEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> evenNumbers = new Queue<int>(input);

            for (int i = 0; i < evenNumbers.Count; i++)
            {
                if (evenNumbers.Peek() % 2 == 1)
                {
                    evenNumbers.Dequeue();
                    i--;
                }
                else
                {
                    evenNumbers.Enqueue(evenNumbers.Dequeue());
                }
            }

            Console.WriteLine(string.Join(", ",evenNumbers));
        }
    }
}
