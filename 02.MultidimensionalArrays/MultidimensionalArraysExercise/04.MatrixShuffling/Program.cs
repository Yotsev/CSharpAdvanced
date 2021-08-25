using System;
using System.Linq;

namespace _04.MatrixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = ReadArray();

            string[,] matrix = new string[matrixSize[0], matrixSize[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] rowNumbers = Console.ReadLine()
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowNumbers[col];
                }
            }

            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] commandArgs = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (commandArgs[0] != "swap" 
                    || commandArgs.Length != 5 
                    || int.Parse(commandArgs[1])<0
                    || int.Parse(commandArgs[1])>=matrix.GetLength(0)
                    || int.Parse(commandArgs[2]) < 0
                    || int.Parse(commandArgs[2]) >= matrix.GetLength(1)
                    || int.Parse(commandArgs[3]) < 0
                    || int.Parse(commandArgs[3]) >= matrix.GetLength(0)
                    || int.Parse(commandArgs[4]) < 0
                    || int.Parse(commandArgs[4]) >= matrix.GetLength(1))
                {
                    Console.WriteLine("Invalid input!");
                }
                else
                {
                    int firstRowIndex = int.Parse(commandArgs[1]);
                    int firstColIndex = int.Parse(commandArgs[2]);
                    int secondRowIndex = int.Parse(commandArgs[3]);
                    int secondColIndex = int.Parse(commandArgs[4]);

                    string temp = string.Empty;

                    temp = matrix[firstRowIndex, firstColIndex];
                    matrix[firstRowIndex, firstColIndex] = matrix[secondRowIndex, secondColIndex];
                    matrix[secondRowIndex, secondColIndex] = temp;

                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        for (int col = 0; col < matrix.GetLength(1)-1; col++)
                        {
                            Console.Write($"{matrix[row,col]} ");
                        }

                        Console.WriteLine($"{matrix[row,matrix.GetLength(1)-1]}");
                    }

                }

                command = Console.ReadLine();
            }
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
