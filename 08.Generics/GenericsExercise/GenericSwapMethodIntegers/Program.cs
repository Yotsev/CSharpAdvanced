using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethodIntegers
{
    class Program
    {
        static void Main(string[] args)
        {

            int numberOfBoxes = int.Parse(Console.ReadLine());

            List<Box<int>> boxes = new List<Box<int>>();

            for (int i = 0; i < numberOfBoxes; i++)
            {
                int input = int.Parse(Console.ReadLine());
                Box<int> currentBox = new Box<int>();

                currentBox.Value = input;
                boxes.Add(currentBox);
            }

            int[] indices = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int firstIndex = indices[0];
            int secondIndex = indices[1];

            SwapElements<int>(boxes, firstIndex, secondIndex);

            foreach (Box<int> box in boxes)
            {
                Console.WriteLine(box);
            }
        }
        public static void SwapElements<T>(List<Box<T>> elements, int firstIndex, int seconIndex)
        {
            Box<T> temp = elements[firstIndex];
            elements[firstIndex] = elements[seconIndex];
            elements[seconIndex] = temp;
        }
    }
}
