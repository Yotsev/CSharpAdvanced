using System;
using System.Collections.Generic;
using System.Linq;

namespace Lootbox
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] lootBoxOne = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] lootBoxTwo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> firstLootBox = new Queue<int>(lootBoxOne);
            Stack<int> secondLootBox = new Stack<int>(lootBoxTwo);

            List<int> claimedItems = new List<int>();

            while (firstLootBox.Count > 0 && secondLootBox.Count > 0)
            {
                if ((firstLootBox.Peek() + secondLootBox.Peek()) % 2 == 0)
                {
                    claimedItems.Add(firstLootBox.Dequeue() + secondLootBox.Pop());
                }
                else
                {
                    firstLootBox.Enqueue(secondLootBox.Pop());
                }
            }

            if (firstLootBox.Count == 0)
            {
                Console.WriteLine("First lootbox is empty");
            }
            else
            {
                Console.WriteLine("Second lootbox is empty");
            }

            int sumOfclaimedItems = claimedItems.Sum();

            if (sumOfclaimedItems >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {sumOfclaimedItems}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {sumOfclaimedItems}");
            }
        }
    }
}
