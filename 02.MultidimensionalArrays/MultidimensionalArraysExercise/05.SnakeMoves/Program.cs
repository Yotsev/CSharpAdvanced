using System;
using System.Linq;

namespace _05.SnakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = ReadArray();
            string snake = Console.ReadLine();

            char[,] stairs = new char[matrixSize[0], matrixSize[1]];

            int currnetSnakePart = 0;

            for (int row = 0; row < stairs.GetLength(0); row++)
            {
                if (row %2 == 0)
                {
                    for (int col = 0; col < stairs.GetLength(1); col++)
                    {
                        stairs[row, col] = snake[currnetSnakePart];
                        currnetSnakePart++;
                        if (currnetSnakePart == snake.Length)
                        {
                            currnetSnakePart = 0;
                        }
                    }
                }
                else
                {
                    for (int col = stairs.GetLength(1) - 1; col >= 0; col--)
                    {
                        stairs[row, col] = snake[currnetSnakePart];
                        currnetSnakePart++;
                        if (currnetSnakePart == snake.Length)
                        {
                            currnetSnakePart = 0;
                        }
                    }
                }
            }

            for (int row = 0; row < stairs.GetLength(0); row++)
            {
                for (int col = 0; col < stairs.GetLength(1)-1; col++)
                {
                    Console.Write($"{stairs[row,col]}");
                }

                Console.WriteLine(stairs[row,stairs.GetLength(1)-1]);
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
