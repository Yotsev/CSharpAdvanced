using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MaximumAndMinimumElement
{
    class Program
    {
        static void Main(string[] args)
        {

            int numberOfQueries = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < numberOfQueries; i++)
            {
                int[] querie = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
               
                if (querie[0]==1)
                {
                    stack.Push(querie[1]);
                }
                else if (querie[0]==2)
                {
                    stack.Pop();
                }
                else if (querie[0]==3)
                {
                    if (stack.Count>0)
                    {
                        Console.WriteLine(stack.Max());
                    }
                }
                else if (querie[0] == 4)
                {
                    if (stack.Count>0)
                    {
                        Console.WriteLine(stack.Min());
                    }
                }
            }

            Console.WriteLine(string.Join(", ",stack));
        }
    }
}
