using System;
using System.Collections.Generic;

namespace GenericCountMethodDoubles
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfBoxes = int.Parse(Console.ReadLine());

            List<Box<double>> boxes = new List<Box<double>>();

            for (int i = 0; i < numberOfBoxes; i++)
            {
                double input = double.Parse(Console.ReadLine());
                Box<double> currentBox = new Box<double>();
                currentBox.Value = input;
                boxes.Add(currentBox);
            }

            Box<double> evaluationBox = new Box<double>();
            evaluationBox.Value = double.Parse(Console.ReadLine());

            Console.WriteLine(CountOfGreaterElements(boxes, evaluationBox));
        }

        public static int CountOfGreaterElements<T>(List<Box<T>> elements, Box<T> compareElement)
            where T : IComparable
        {
            int count = 0;

            foreach (Box<T> box in elements)
            {
                if (box.Value.CompareTo(compareElement.Value) > 0)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
