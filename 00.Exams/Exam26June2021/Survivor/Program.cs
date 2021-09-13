using System;
using System.Linq;

namespace Survivor
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            char[][] beach = new char[rows][];

            for (int row = 0; row < beach.Length; row++)
            {
                char[] rowElements = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                beach[row] = rowElements;
            }

            string command = Console.ReadLine();

            int collectedTokens = 0;
            int opponentTokens = 0;

            while (command != "Gong")
            {
                string[] commandArgs = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string action = commandArgs[0];
                int row = int.Parse(commandArgs[1]);
                int col = int.Parse(commandArgs[2]);

                bool isValidLocation = ValidLocation(beach, row, col);

                if (action == "Find")
                {
                    if (isValidLocation)
                    {
                        if (beach[row][col] == 'T')
                        {
                            collectedTokens++;
                            beach[row][col] = '-';
                        }
                    }
                }
                else if (action == "Opponent")
                {
                    string direction = commandArgs[3];


                    if (isValidLocation)
                    {
                        if (beach[row][col] == 'T')
                        {
                            opponentTokens++;
                            beach[row][col] = '-';
                        }

                        if (direction == "up")
                        {
                            opponentTokens = OponentMomentUp(beach, row, col, opponentTokens);
                        }
                        else if (direction == "down")
                        {
                            opponentTokens = OponentMomentDown(beach, row, col, opponentTokens);
                        }
                        else if (direction == "left")
                        {
                            opponentTokens = OponentMomentLeft(beach, row, col, opponentTokens);
                        }
                        else if (direction == "right")
                        {
                            opponentTokens = OponentMomentRight(beach, row, col, opponentTokens);
                        }
                    }
                }

                command = Console.ReadLine();
            }

            PrintBeach(beach);
            Console.WriteLine($"Collected tokens: {collectedTokens}");
            Console.WriteLine($"Opponent's tokens: {opponentTokens}");

        }

        private static int OponentMomentRight(char[][] beach, int row, int col, int tokens)
        {
            int steps = 3;
            int targetCol = col;

            while (steps > 0)
            {
                targetCol++;

                if (targetCol >= beach[row].Length)
                {
                    targetCol = beach[row].Length - 1;

                    if (beach[row][targetCol] == 'T')
                    {
                        tokens++;
                        beach[row][targetCol] = '-';
                    }
                }
                else
                {
                    if (beach[row][targetCol] == 'T')
                    {
                        tokens++;
                        beach[row][targetCol] = '-';
                    }
                }

                steps--;
            }

            return tokens;
        }

        private static int OponentMomentLeft(char[][] beach, int row, int col, int tokens)
        {
            int steps = 3;
            int targetCol = col;

            while (steps > 0)
            {
                targetCol--;

                if (targetCol < 0)
                {
                    targetCol = 0;

                    if (beach[row][targetCol] == 'T')
                    {
                        tokens++;
                        beach[row][targetCol] = '-';
                    }
                }
                else
                {
                    if (beach[row][targetCol] == 'T')
                    {
                        tokens++;
                        beach[row][targetCol] = '-';
                    }
                }

                steps--;
            }

            return tokens;
        }

        private static int OponentMomentDown(char[][] beach, int row, int col, int tokens)
        {
            int steps = 3;
            int targetRow = row;

            while (steps > 0)
            {
                targetRow++;

                if (targetRow >= beach.Length)
                {
                    targetRow = beach.Length - 1;

                    if (beach[targetRow][col] == 'T')
                    {
                        tokens++;
                        beach[targetRow][col] = '-';
                    }
                }
                else
                {
                    if (beach[targetRow][col] == 'T')
                    {
                        tokens++;
                        beach[targetRow][col] = '-';
                    }
                }

                steps--;
            }

            return tokens;
        }

        private static int OponentMomentUp(char[][] beach, int row, int col, int tokens)
        {
            int steps = 3;
            int targetRow = row;

            while (steps > 0)
            {
                targetRow--;

                if (targetRow < 0)
                {
                    targetRow = 0;

                    if (beach[targetRow][col] == 'T')
                    {
                        tokens++;
                        beach[targetRow][col] = '-';
                    }
                }
                else
                {
                    if (beach[targetRow][col] == 'T')
                    {
                        tokens++;
                        beach[targetRow][col] = '-';
                    }
                }

                steps--;
            }

            return tokens;
        }

        private static bool ValidLocation(char[][] beach, int row, int col)
        {
            return row >= 0 && row < beach.Length
                        && col >= 0 && col < beach[row].Length;
        }

        private static void PrintBeach(char[][] beach)
        {
            for (int row = 0; row < beach.Length; row++)
            {
                Console.WriteLine(string.Join(" ", beach[row]));
            }
        }
    }
}
