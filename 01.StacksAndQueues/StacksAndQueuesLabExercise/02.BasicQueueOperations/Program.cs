using System;
using System.Linq;
using System.Collections.Generic;

namespace _02.BasicQueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] operationNumbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int numbersToQueue = operationNumbers[0];
            int numbersToDequeue = operationNumbers[1];
            int targetNumber = operationNumbers[2];

            Queue<int> queue = new Queue<int>();

            for (int i = 0; i < numbersToQueue; i++)
            {
                queue.Enqueue(numbers[i]);
            }

            for (int i = 0; i < numbersToDequeue; i++)
            {
                queue.Dequeue();
            }

            if (queue.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (queue.Contains(targetNumber))
            {
                Console.WriteLine(queue.Contains(targetNumber).ToString().ToLower());
            }
            else
            {
                int smallestNummber = int.MaxValue;

                while (queue.Count>0)
                {
                    if (queue.Peek()< smallestNummber)
                    {
                        smallestNummber = queue.Peek();
                    }

                    queue.Dequeue();
                }

                Console.WriteLine(smallestNummber);
            }
        }
    }
}
