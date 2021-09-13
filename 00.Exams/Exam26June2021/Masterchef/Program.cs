using System;
using System.Linq;
using System.Collections.Generic;

namespace Masterchef
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] ingredientsValues = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] freshnessValues = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Reverse()
                .ToArray();

            Dictionary<string, int> dishes = new Dictionary<string, int>()
            {
                {"Dipping sauce", 150},
                { "Green salad",250},
                { "Chocolate cake",300},
                { "Lobster",400}
            };

            Queue<int> ingredients = new Queue<int>(ingredientsValues);
            Queue<int> freshness = new Queue<int>(freshnessValues);

            Dictionary<string, int> madeDishesh = new Dictionary<string, int>();



            while (ingredients.Count > 0 && freshness.Count > 0)
            {
                if (ingredients.Peek() == 0)
                {
                    ingredients.Dequeue();
                    continue;
                }

                KeyValuePair<string, int> dish = dishes.FirstOrDefault(d => d.Value == ingredients.Peek() * freshness.Peek());

                if (dish.Key != null)
                {
                    if (!madeDishesh.ContainsKey(dish.Key))
                    {
                        madeDishesh.Add(dish.Key, 1);
                    }
                    else
                    {
                        madeDishesh[dish.Key]++;
                    }

                    ingredients.Dequeue();
                    freshness.Dequeue();
                }
                else
                {
                    freshness.Dequeue();
                    ingredients.Enqueue(ingredients.Dequeue() + 5);
                }
            }

            bool isSuccessful = false;

            if (madeDishesh.Count == 4)
            {
                isSuccessful = true;
            }

            if (isSuccessful)
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }

            if (ingredients.Count > 0)
            {
                Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
            }

            foreach (var item in madeDishesh.OrderBy(n => n.Key))
            {
                Console.WriteLine($"# {item.Key} --> {item.Value}");
            }
        }
    }
}
