using System;
using System.Linq;

namespace _02.SquaresInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            char[,] matrix = new char[matrixSize[0], matrixSize[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] rowChars = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowChars[col];
                }
            }

            int countOfSubMatrices = 0; 

            for (int row = 0; row < matrix.GetLength(0)-1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1)-1; col++)
                {
                    if (
                        matrix[row, col] == matrix[row,col+1]
                        && matrix[row,col] == matrix[row+1, col]
                        && matrix[row,col] == matrix[row+1, col+1]
                        )
                    {
                        countOfSubMatrices++;
                    }
                }
            }

            Console.WriteLine(countOfSubMatrices);
        }
    }
}
