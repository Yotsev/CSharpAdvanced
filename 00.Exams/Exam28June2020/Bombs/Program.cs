using System;
using System.Linq;
using System.Collections.Generic;

namespace Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] bombEffects = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] bombCasings = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Dictionary<string, int[]> materials = new Dictionary<string, int[]>()
            {
                { "Datura Bombs", new int[]{ 40,0 } },
                { "Cherry Bombs", new int[]{ 60,0} },
                {"Smoke Decoy Bombs", new int[] { 120,0 } }
            };


            Queue<int> effects = new Queue<int>(bombEffects);
            Stack<int> casings = new Stack<int>(bombCasings);

            bool isFull = false;

            while (effects.Count > 0 && casings.Count > 0)
            {
                if (materials.Any(x => x.Value[0] == effects.Peek() + casings.Peek()))
                {
                    materials[materials.First(x => x.Value[0] == effects.Peek() + casings.Peek()).Key][1]++;
                    effects.Dequeue();
                    casings.Pop();
                }
                else
                {
                    casings.Push(casings.Pop() - 5);
                    continue;
                }

                if (materials.All(x => x.Value[1] >= 3))
                {
                    isFull = true;
                    break;
                }
            }

            if (isFull)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            if (effects.Count > 0)
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ", effects)}");
            }
            else
            {
                Console.WriteLine("Bomb Effects: empty");
            }

            if (casings.Count > 0)
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ", casings)}");
            }
            else
            {
                Console.WriteLine("Bomb Casings: empty");
            }

            foreach (var bomb in materials.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{bomb.Key}: {bomb.Value[1]}");
            }
        }
    }
}
