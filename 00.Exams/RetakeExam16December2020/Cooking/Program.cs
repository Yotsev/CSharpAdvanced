using System;
using System.Linq;
using System.Collections.Generic;

namespace Cooking
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] liquidsInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] ingredientsInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> liquids = new Queue<int>(liquidsInfo);
            Stack<int> ingredients = new Stack<int>(ingredientsInfo);

            Dictionary<string, int[]> pastries = new Dictionary<string, int[]>()
            {
                { "Bread", new int[]{25,0 } },
                { "Cake", new int [] { 50, 0} },
                {"Pastry", new int[] { 75, 0} },
                { "Fruit Pie", new int[] { 100, 0} }
            };

            while (liquids.Count > 0 && ingredients.Count > 0)
            {
                var pastry = pastries.FirstOrDefault(p => p.Value[0] == liquids.Peek() + ingredients.Peek());

                if (pastry.Key != null)
                {
                    pastries[pastry.Key][1]++;

                    liquids.Dequeue();
                    ingredients.Pop();
                }
                else
                {
                    liquids.Dequeue();
                    ingredients.Push(ingredients.Pop() + 3);
                }
            }

            if (pastries.All(p => p.Value[1] > 0))
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }

            if (liquids.Count == 0)
            {
                Console.WriteLine("Liquids left: none");
            }
            else
            {
                Console.WriteLine($"Liquids left: {string.Join(", ", liquids)}");
            }

            if (ingredients.Count == 0)
            {
                Console.WriteLine("Ingredients left: none");
            }
            else
            {
                Console.WriteLine($"Ingredients left: {string.Join(", ", ingredients)}");
            }

            foreach (var item in pastries.OrderBy(p => p.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value[1]}");
            }
        }
    }
}
