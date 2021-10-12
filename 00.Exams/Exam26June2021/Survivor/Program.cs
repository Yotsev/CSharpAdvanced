using System;
using System.Linq;

namespace Survivor
{
    class Program
    {
        static char[][] beach;
        static void Main(string[] args)
        {
            int beachRows = int.Parse(Console.ReadLine());

            beach = new char[beachRows][];

            ReadBeach();

            string command = Console.ReadLine();

            int collectedTokens = 0;
            int opponentTokens = 0;

            while (command != "Gong")
            {
                string[] commandArgs = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string action = commandArgs[0];
                int targetRow = int.Parse(commandArgs[1]);
                int targetCol = int.Parse(commandArgs[2]);

                if (action == "Find")
                {
                    if (IsValidIndexes(targetRow, targetCol) && beach[targetRow][targetCol] == 'T')
                    {
                        collectedTokens++;
                        beach[targetRow][targetCol] = '-';
                    }
                }
                else if (action == "Opponent")
                {
                    string direction = commandArgs[3];

                    if (IsValidIndexes(targetRow, targetCol) && beach[targetRow][targetCol] == 'T')
                    {
                        opponentTokens++;
                        beach[targetRow][targetCol] = '-';

                        opponentTokens = OponentMovement(direction, opponentTokens, targetRow, targetCol);
                    }
                }


                command = Console.ReadLine();
            }

            PrintBeach();

            Console.WriteLine($"Collected tokens: {collectedTokens}");
            Console.WriteLine($"Opponent's tokens: {opponentTokens}");
        }

        private static int OponentMovement(string direction, int tokens, int row, int col)
        {
            int steps = 3;
            int tokenCount = tokens;

            int targetRow = row;
            int targetCol = col;

            while (steps > 0)
            {
                if (direction == "up")
                {
                    targetRow--;
                }
                else if (direction == "down")
                {
                    targetRow++;
                }
                else if (direction == "left")
                {
                    targetCol--;
                }
                else if (direction == "right")
                {
                    targetCol++;
                }

                if (IsValidIndexes(targetRow, targetCol) && beach[targetRow][targetCol] == 'T')
                {
                    tokenCount++;
                    beach[targetRow][targetCol] = '-';
                }

                steps--;
            }

            return tokenCount;
        }

        private static bool IsValidIndexes(int row, int col)
        {
            return row >= 0 && row < beach.Length
                && col >= 0 && col < beach[row].Length;
        }

        private static void ReadBeach()
        {
            for (int row = 0; row < beach.Length; row++)
            {
                char[] rowInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                beach[row] = rowInfo;
            }
        }

        private static void PrintBeach()
        {
            for (int row = 0; row < beach.Length; row++)
            {
                Console.WriteLine(string.Join(" ", beach[row]));
            }
        }
    }
}
