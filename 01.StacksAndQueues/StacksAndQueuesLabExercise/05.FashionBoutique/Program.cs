using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] clothes = 
                Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int capasityOfRack = int.Parse(Console.ReadLine());

            Stack<int> boxOfClothes = new Stack<int>(clothes);

            int numberOfRacks = 1;

            int currentSum = 0;

            while (boxOfClothes.Count>0)
            {
                currentSum += boxOfClothes.Peek();

                if (currentSum<capasityOfRack)
                {
                    boxOfClothes.Pop();
                }
                else if (currentSum==capasityOfRack)
                {
                    boxOfClothes.Pop();
                    
                    if (boxOfClothes.Count>0)
                    {
                        numberOfRacks++;
                    }
                    currentSum = 0;
                }
                else if (currentSum>capasityOfRack)
                {
                    numberOfRacks++;
                    currentSum = 0;
                }
            }

            Console.WriteLine(numberOfRacks);
        }
    }
}
