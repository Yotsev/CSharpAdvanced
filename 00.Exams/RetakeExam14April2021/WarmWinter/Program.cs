using System;
using System.Linq;
using System.Collections.Generic;

namespace WarmWinter
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] hats = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] scarfs = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> hatsCollection = new Stack<int>(hats);
            Queue<int> scarfsCollection = new Queue<int>(scarfs);

            List<int> sets = new List<int>();
            while (hatsCollection.Count > 0 && scarfsCollection.Count > 0)
            {
                if (hatsCollection.Peek() > scarfsCollection.Peek())
                {
                    sets.Add(hatsCollection.Pop() + scarfsCollection.Dequeue());
                }
                else if (hatsCollection.Peek() < scarfsCollection.Peek())
                {
                    hatsCollection.Pop();
                }
                else
                {
                    scarfsCollection.Dequeue();
                    hatsCollection.Push(hatsCollection.Pop() + 1);
                }
            }

            int mostExpensiveSet = sets.OrderByDescending(x => x).FirstOrDefault();

            Console.WriteLine($"The most expensive set is: {mostExpensiveSet}");
            Console.WriteLine(string.Join(" ", sets));
        }
    }
}