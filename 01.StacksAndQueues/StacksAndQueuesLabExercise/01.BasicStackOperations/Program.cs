using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] stackNumbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int numbersToPush = input[0];
            int numbersToPop = input[1];
            int targetNumber = input[2];

            Stack<int> numbers = new Stack<int>();

            for (int i = 0; i < numbersToPush; i++)
            {
                numbers.Push(stackNumbers[i]);
            }

            for (int i = 0; i < numbersToPop; i++)
            {
                numbers.Pop();
            }


            if (numbers.Contains(targetNumber))
            {
                Console.WriteLine(numbers.Contains(targetNumber).ToString().ToLower());
            }
            else
            {
                if (numbers.Count == 0)
                {
                    Console.WriteLine(0);
                }
                else
                {
                    int smallestNumber = int.MaxValue;

                    while (numbers.Count > 0)
                    {
                        if (numbers.Peek() < smallestNumber)
                        {
                            smallestNumber = numbers.Peek();
                        }

                        numbers.Pop();
                    }

                    Console.WriteLine(smallestNumber);
                }
            }
        }
    }
}
