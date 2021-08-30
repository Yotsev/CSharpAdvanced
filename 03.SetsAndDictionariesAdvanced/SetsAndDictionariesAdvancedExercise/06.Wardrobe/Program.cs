using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfinputs = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> clothes = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < numberOfinputs; i++)
            {
                string[] clothesInfo = Console.ReadLine()
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                string color = clothesInfo[0];
                string[] items = clothesInfo[1]
                    .Split(",", StringSplitOptions.RemoveEmptyEntries);


                if (!clothes.ContainsKey(color))
                {
                    clothes.Add(color, new Dictionary<string, int>());
                }

                foreach (var item in items)
                {
                    if (!clothes[color].ContainsKey(item))
                    {
                        clothes[color].Add(item, 0);
                    }

                    clothes[color][item]++;
                }
            }

            string[] itemInfo = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries);

            string colorNeeded = itemInfo[0];
            string itemNeeded = itemInfo[1];

            foreach (var color in clothes)
            {
                Console.WriteLine($"{color.Key} clothes:");

                foreach (var item in color.Value)
                {
                    string output = $"* {item.Key} - {item.Value}";

                    if (colorNeeded == color.Key && itemNeeded == item.Key)
                    {
                        output += " (found!)";
                    }

                    Console.WriteLine(output);
                }
            }
        }
    }
}
