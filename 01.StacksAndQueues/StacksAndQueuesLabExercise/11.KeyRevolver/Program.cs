using System;
using System.Linq;
using System.Collections.Generic;

namespace _11.KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int sizeOfBarrel = int.Parse(Console.ReadLine());
            int[] bulletsInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] locksInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int valueOfIntelligence = int.Parse(Console.ReadLine());

            Stack<int> bullets = new Stack<int>(bulletsInfo);
            Queue<int> locks = new Queue<int>(locksInfo);

            bool areLocksDestoryed = false;
            int shots = 0;

            while (bullets.Count > 0 && locks.Count > 0)
            {
                if (bullets.Peek() <= locks.Peek())
                {
                    bullets.Pop();
                    locks.Dequeue();
                    valueOfIntelligence -= bulletPrice;
                    Console.WriteLine("Bang!");
                }
                else
                {
                    bullets.Pop();
                    valueOfIntelligence -= bulletPrice;
                    Console.WriteLine("Ping!");
                }

                shots++;

                if (shots % sizeOfBarrel == 0 && bullets.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                }

                if (locks.Count == 0)
                {
                    areLocksDestoryed = true;
                }
            }

            if (areLocksDestoryed)
            {
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${valueOfIntelligence}");
            }
            else
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
        }
    }
}
