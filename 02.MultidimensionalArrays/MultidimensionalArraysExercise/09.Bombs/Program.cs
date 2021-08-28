using System;
using System.Linq;

namespace _09.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeOfMatrix = int.Parse(Console.ReadLine());

            int[,] field = new int[sizeOfMatrix, sizeOfMatrix];

            for (int row = 0; row < field.GetLength(0); row++)
            {
                int[] rows = ReadArray();

                for (int col = 0; col < field.GetLength(1); col++)
                {
                    field[row, col] = rows[col];
                }
            }

            int[] bombCoordinates = ReadArray();

            for (int i = 0; i < bombCoordinates.Length; i += 2)
            {
                int bombRow = bombCoordinates[i];
                int bombCol = bombCoordinates[i + 1];
                Explosion(field, bombRow, bombCol);
            }

            int aliveCells = 0;
            int sum = 0;
            
            foreach (int item in field)
            {
                if (item > 0)
                {
                    aliveCells++;
                    sum += item;
                }
            }

            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {sum}");
            PrintField(field);
        }

        private static void Explosion(int[,] field, int bombRow, int bombCol)
        {
            if (field[bombRow, bombCol] > 0)
            {
                if (ValidTargetCell(field, bombRow - 1, bombCol - 1) && field[bombRow - 1, bombCol - 1] > 0)
                {
                    field[bombRow - 1, bombCol - 1] -= field[bombRow, bombCol];
                }

                if (ValidTargetCell(field, bombRow - 1, bombCol) && field[bombRow - 1, bombCol] > 0)
                {
                    field[bombRow - 1, bombCol] -= field[bombRow, bombCol];
                }

                if (ValidTargetCell(field, bombRow - 1, bombCol + 1) && field[bombRow - 1, bombCol + 1] > 0)
                {
                    field[bombRow - 1, bombCol + 1] -= field[bombRow, bombCol];
                }

                if (ValidTargetCell(field, bombRow, bombCol - 1) && field[bombRow, bombCol - 1] > 0)
                {
                    field[bombRow, bombCol - 1] -= field[bombRow, bombCol];
                }

                if (ValidTargetCell(field, bombRow, bombCol + 1) && field[bombRow, bombCol + 1] > 0)
                {
                    field[bombRow, bombCol + 1] -= field[bombRow, bombCol];
                }

                if (ValidTargetCell(field, bombRow + 1, bombCol - 1) && field[bombRow + 1, bombCol - 1] > 0)
                {
                    field[bombRow + 1, bombCol - 1] -= field[bombRow, bombCol];
                }

                if (ValidTargetCell(field, bombRow + 1, bombCol) && field[bombRow + 1, bombCol] > 0)
                {
                    field[bombRow + 1, bombCol] -= field[bombRow, bombCol];
                }

                if (ValidTargetCell(field, bombRow + 1, bombCol + 1) && field[bombRow + 1, bombCol + 1] > 0)
                {
                    field[bombRow + 1, bombCol + 1] -= field[bombRow, bombCol];
                }

                field[bombRow, bombCol] = 0;
            }
        }

        private static int[] ReadArray()
        {
            return Console.ReadLine()
            .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
        }

        private static bool ValidTargetCell(int[,] field, int targetRow, int targetCol)
        {
            return targetRow >= 0 && targetRow < field.GetLength(0)
                && targetCol >= 0 && targetCol < field.GetLength(1);
        }

        private static void PrintField(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine(matrix[row, matrix.GetLength(1) - 1]);
            }
        }
    }
}
