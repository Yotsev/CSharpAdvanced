using System;
using System.Linq;

namespace _01.SumMatrixElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizeOfMatrix = ReadArray();

            int[,] matix = new int[sizeOfMatrix[0], sizeOfMatrix[1]];

            int sum = 0;

            for (int i = 0; i < matix.GetLength(0); i++)
            {
                int[] row = ReadArray();

                for (int j = 0; j < matix.GetLength(1); j++)
                {
                    matix[i, j] = row[j];
                    sum += row[j];
                }
            }

            Console.WriteLine(matix.GetLength(0));
            Console.WriteLine(matix.GetLength(1));
            Console.WriteLine(sum);
        }

        private static int[] ReadArray()
        {
            return Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
        }
    }
}
