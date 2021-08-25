using System;
using System.Linq;

namespace _01.DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeOfMatrix = int.Parse(Console.ReadLine());

            int[,] matrix = new int[sizeOfMatrix, sizeOfMatrix];

            for (int i = 0; i < sizeOfMatrix; i++)
            {
                int[] rowNubers = ReadArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = rowNubers[j];
                }
            }

            int primeryDiagonalSum = 0;
            int secondaryDiagonalSUm = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (row == col)
                    {
                        primeryDiagonalSum += matrix[row, col];
                    }

                    if (col == matrix.GetLength(1) - 1 - row)
                    {
                        secondaryDiagonalSUm += matrix[row, col];
                    }
                }
            }

            Console.WriteLine(Math.Abs(primeryDiagonalSum-secondaryDiagonalSUm));

        }

        private static int[] ReadArray()
        {
            return Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
