using System;
using System.Linq;
using System.Collections.Generic;

namespace _04.FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantityOfFood = int.Parse(Console.ReadLine());
            int[] quantityOfOrders = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> orders = new Queue<int>(quantityOfOrders);

            Console.WriteLine(orders.Max());

            while (true)
            {
                if (quantityOfFood>orders.Peek())
                {
                    quantityOfFood -= orders.Dequeue();
                }

                if (orders.Count == 0 || quantityOfFood< orders.Peek())
                {
                    break;
                }
            }

            if (orders.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine($"Orders left: {string.Join(" ",orders)}");
            }
        }
    }
}
