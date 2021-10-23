using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] vowelsInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse)
                .ToArray();

            char[] consonantsInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse)
                .ToArray();

            Queue<char> vowels = new Queue<char>(vowelsInfo);
            Stack<char> consonants = new Stack<char>(consonantsInfo);

            List<string> products = new List<string>() { "pear", "flour", "pork", "olive" };

            Dictionary<string, List<char>> foundProducts = new Dictionary<string, List<char>>();

            while (consonants.Count > 0)
            {
                var currentvowel = vowels.Peek();
                vowels.Enqueue(vowels.Dequeue());
                var currentconsonant = consonants.Pop();

                foreach (var item in products)
                {
                    if (item.Contains(currentvowel))
                    {
                        if (!foundProducts.ContainsKey(item))
                        {
                            foundProducts.Add(item, new List<char>());
                        }

                        if (!foundProducts[item].Contains(currentvowel))
                        {
                            foundProducts[item].Add(currentvowel);
                        }
                    }

                    if (item.Contains(currentconsonant))
                    {
                        if (!foundProducts.ContainsKey(item))
                        {
                            foundProducts.Add(item, new List<char>());
                        }

                        if (!foundProducts[item].Contains(currentconsonant))
                        {
                            foundProducts[item].Add(currentconsonant);
                        }
                    }
                }
            }

            List<string> itmesToPrint = foundProducts.Where(p => p.Key.Length == p.Value.Count).Select(kvp => kvp.Key).ToList().OrderBy(x => products.IndexOf(x)).ToList();

            Console.WriteLine($"Words found: {itmesToPrint.Count}");
            foreach (var item in itmesToPrint)
            {
                Console.WriteLine(item);
            }
        }
    }
}
