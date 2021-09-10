using System;
using System.Linq;
using System.Collections.Generic;

namespace _12.CupsAndBottles
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] cupCapacity = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] filledBottles = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> cups = new Stack<int>(cupCapacity.Reverse());
            Stack<int> bottles = new Stack<int>(filledBottles);

            int wastedLitters = 0;
            bool allCupsAreFilled = false;

            while (bottles.Count > 0 && cups.Count > 0)
            {
                if (cups.Peek() > bottles.Peek())
                {
                    cups.Push(cups.Pop() - bottles.Pop());
                }
                else if (cups.Peek() <= bottles.Peek())
                {
                    wastedLitters += bottles.Pop() - cups.Pop();
                }

                if (cups.Count == 0)
                {
                    allCupsAreFilled = true;
                }
            }

            if (allCupsAreFilled)
            {
                Console.WriteLine($"Bottles: {string.Join(" ",bottles)}");
            }
            else
            {
                Console.WriteLine($"Cups: {string.Join(" ",cups)}");
            }

            Console.WriteLine($"Wasted litters of water: {wastedLitters}");
        }
    }
}
