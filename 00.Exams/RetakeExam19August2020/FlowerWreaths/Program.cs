using System;
using System.Linq;
using System.Collections.Generic;

namespace FlowerWreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rosesInfo = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] liliesInfo = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> roses = new Queue<int>(rosesInfo);
            Stack<int> lilies = new Stack<int>(liliesInfo);

            int wreaths = 0;
            int storedFlowers = 0;
            while (roses.Count > 0 && lilies.Count > 0)
            {
                if (roses.Peek() + lilies.Peek() == 15)
                {
                    wreaths++;
                    roses.Dequeue();
                    lilies.Pop();
                }
                else if (roses.Peek() + lilies.Peek() > 15)
                {
                    while (roses.Peek() + lilies.Peek() > 15)
                    {
                        lilies.Push(lilies.Pop() - 2);
                    }

                    wreaths++;
                    roses.Dequeue();
                    lilies.Pop();
                }
                else if (roses.Peek() + lilies.Peek() < 15)
                {
                    storedFlowers += roses.Dequeue() + lilies.Pop();
                }
            }
            if (storedFlowers > 0)
            {
                wreaths += storedFlowers / 15;
            }

            if (wreaths >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreaths} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5 - wreaths} wreaths more!");
            }
        }
    }
}
