using System;
using System.Collections.Generic;
using System.Linq;

namespace BirthdayCelebration
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] eatingCapacity = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] plateCapacity = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> plates = new Stack<int>(plateCapacity);
            Stack<int> guests = new Stack<int>(eatingCapacity.Reverse());

            int wastedFood = 0;

            while (plates.Count > 0 && guests.Count > 0)
            {
                if (guests.Peek() > plates.Peek())
                {
                    guests.Push(guests.Pop() - plates.Pop());
                }
                else if (guests.Peek() <= plates.Peek())
                {
                    wastedFood += plates.Pop() - guests.Pop();
                }
            }

            if (guests.Count == 0)
            {
                Console.WriteLine($"Plates: {string.Join(" ",plates)}");
            }
            else
            {
                Console.WriteLine($"Guests: {string.Join(" ",guests)}");
            }

            Console.WriteLine($"Wasted grams of food: {wastedFood}");
        }
    }
}
