using System;

namespace _04.SymbolInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeOfMatrix = int.Parse(Console.ReadLine());

            char[,] matix = new char[sizeOfMatrix, sizeOfMatrix];

            for (int row = 0; row < matix.GetLength(0); row++)
            {
                string matixRow = Console.ReadLine();

                for (int col = 0; col < matix.GetLength(1); col++)
                {
                    matix[row, col] = matixRow[col];
                }
            }

            char symbol = char.Parse(Console.ReadLine());
            bool isFound = false;
            for (int row = 0; row < matix.GetLength(0); row++)
            {
                for (int col = 0; col < matix.GetLength(1); col++)
                {
                    if (matix[row,col] == symbol)
                    {
                        Console.WriteLine($"({row}, {col})");
                        isFound = true;
                        break;
                    }
                }

                if (isFound)
                {
                    break;
                }
            }

            if (!isFound)
            {
                Console.WriteLine($"{symbol} does not occur in the matrix");
            }
        }
    }
}
