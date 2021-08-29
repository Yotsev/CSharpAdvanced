using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.RadioactiveMutantVampireBunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] lairSize = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            char[,] lair = new char[lairSize[0], lairSize[1]];
            int playerRow = -1;
            int playerCol = -1;

            for (int row = 0; row < lair.GetLength(0); row++)
            {
                char[] rows = Console.ReadLine().ToCharArray();

                for (int col = 0; col < lair.GetLength(1); col++)
                {
                    lair[row, col] = rows[col];

                    if (rows[col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            char[] actions = Console.ReadLine().ToCharArray();
            bool isPlayerWon = false;
            bool isPlayerDead = false;

            foreach (char diraction in actions)
            {
                int newPlayerRow = playerRow;
                int newPlayerCol = playerCol;

                if (diraction == 'U')
                {
                    newPlayerRow--;
                }
                else if (diraction == 'D')
                {
                    newPlayerRow++;
                }
                else if (diraction == 'L')
                {
                    newPlayerCol--;
                }
                else if (diraction == 'R')
                {
                    newPlayerCol++;
                }

                lair[playerRow, playerCol] = '.';
                isPlayerWon = !IsValidCell(newPlayerRow, newPlayerCol, lairSize[0], lairSize[1]);

                if (!isPlayerWon)
                {
                    if (lair[newPlayerRow, newPlayerCol] == '.')
                    {
                        lair[newPlayerRow, newPlayerCol] = 'P';
                    }
                    else if (lair[newPlayerRow, newPlayerCol] == 'B')
                    {
                        isPlayerDead = true;
                    }

                    playerRow = newPlayerRow;
                    playerCol = newPlayerCol;
                }

                List<int[]> bunnyIndex = GetBunniesIndexes(lair);
                BunnyMultiplay(bunnyIndex, lair);

                if (lair[playerRow, playerCol] == 'B')
                {
                    isPlayerDead = true;
                }

                if (isPlayerWon || isPlayerDead)
                {
                    break;
                }
            }

            PrintLair(lair);

            string result = string.Empty;

            if (isPlayerWon)
            {
                result += "won:";
            }
            else
            {
                result += "dead:";
            }

            result += $" {playerRow} {playerCol}";
            Console.WriteLine(result);
        }

        private static void PrintLair(char[,] lair)
        {
            for (int row = 0; row < lair.GetLength(0); row++)
            {
                for (int col = 0; col < lair.GetLength(1); col++)
                {
                    Console.Write(lair[row,col]);
                }

                Console.WriteLine();
            }
        }

        private static void BunnyMultiplay(List<int[]> bunnyIndex, char[,] lair)
        {
            foreach (int[] bunny in bunnyIndex)
            {
                int bunnyRow = bunny[0];
                int bunnyCol = bunny[1];

                if (IsValidCell(bunnyRow - 1, bunnyCol, lair.GetLength(0), lair.GetLength(1)))
                {
                    lair[bunnyRow - 1, bunnyCol] = 'B';
                }

                if (IsValidCell(bunnyRow + 1, bunnyCol, lair.GetLength(0), lair.GetLength(1)))
                {
                    lair[bunnyRow + 1, bunnyCol] = 'B';
                }

                if (IsValidCell(bunnyRow, bunnyCol - 1, lair.GetLength(0), lair.GetLength(1)))
                {
                    lair[bunnyRow, bunnyCol - 1] = 'B';
                }

                if (IsValidCell(bunnyRow, bunnyCol + 1, lair.GetLength(0), lair.GetLength(1)))
                {
                    lair[bunnyRow, bunnyCol + 1] = 'B';
                }
            }
        }

        private static List<int[]> GetBunniesIndexes(char[,] lair)
        {
            List<int[]> bunnies = new List<int[]>();

            for (int row = 0; row < lair.GetLength(0); row++)
            {
                for (int col = 0; col < lair.GetLength(1); col++)
                {
                    if (lair[row, col] == 'B')
                    {
                        bunnies.Add(new int[] { row, col });
                    }
                }
            }

            return bunnies;
        }

        private static bool IsValidCell(int newPlayerRow, int newPlayerCol, int rows, int cols)
        {
            return newPlayerRow >= 0 && newPlayerRow < rows && newPlayerCol >= 0 && newPlayerCol < cols;
        }
    }
}
