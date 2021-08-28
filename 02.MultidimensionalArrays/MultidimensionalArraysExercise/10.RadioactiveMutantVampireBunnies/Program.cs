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

            for (int row = 0; row < lair.GetLength(0); row++)
            {
                string rows = Console.ReadLine();

                for (int col = 0; col < lair.GetLength(1); col++)
                {
                    lair[row, col] = rows[col];
                }
            }

            string commands = Console.ReadLine();

            int[] playerPosition = GetPosition(lair);

            bool playerWon = false;

            for (int i = 0; i < commands.Length; i++)
            {
                char direction = commands[i];
                int targetRow = 0;
                int targetCol = 0;

                if (direction == 'U')
                {
                    targetRow = playerPosition[0] - 1;
                    targetCol = playerPosition[1];
                }
                else if (direction == 'D')
                {
                    targetRow = playerPosition[0] + 1;
                    targetCol = playerPosition[1];
                }
                else if (direction == 'L')
                {
                    targetRow = playerPosition[0];
                    targetCol = playerPosition[1]-1;
                }
                else if (direction == 'R')
                {
                    targetRow = playerPosition[0];
                    targetCol = playerPosition[1] + 1;
                }

                if (IsInLair(lair,targetRow,targetCol))
                {
                    if (lair[targetRow,targetCol] == '.')
                    {
                        lair[targetRow, targetCol] = 'P';
                        lair[playerPosition[0], playerPosition[1]] = '.';
                        playerPosition = GetPosition(lair);
                        RabbitsMultiplay(lair);
                    }
                    else
                    {
                        lair[playerPosition[0], playerPosition[1]] = '.';
                        playerPosition = new int[] { targetRow, targetCol };
                        RabbitsMultiplay(lair);
                        break;
                    }
                }
                else
                {
                    lair[playerPosition[0], playerPosition[1]] = '.';
                    RabbitsMultiplay(lair);
                    playerWon = true;
                    break;
                }
            }

            if (playerWon)
            {
                PrintLair(lair);
                Console.WriteLine($"won: {playerPosition[0]} {playerPosition[1]}");
            }
            else
            {
                PrintLair(lair);
                Console.WriteLine($"dead: {playerPosition[0]} {playerPosition[1]}");
            }
        }

        private static void RabbitsMultiplay(char[,] lair)
        {
            List<int> rabbitsPositon = GetRabbits(lair);
            bool playerDead = false;
            for (int i = 0; i < rabbitsPositon.Count; i+=2)
            {
                int[] positionToMultiplay = new int[] { 
                    rabbitsPositon[i]-1,rabbitsPositon[i+1],
                    rabbitsPositon[i],rabbitsPositon[i+1]-1,
                    rabbitsPositon[i]+1,rabbitsPositon[i+1],
                    rabbitsPositon[i],rabbitsPositon[i+1]+1
                };

                for (int j = 0; j < positionToMultiplay.Length; j+=2)
                {
                    if (RabbitCanMultyplay(lair,positionToMultiplay[j],positionToMultiplay[j+1]))
                    {
                        if (lair[positionToMultiplay[j], positionToMultiplay[j + 1]] == '.')
                        {
                            lair[positionToMultiplay[j], positionToMultiplay[j + 1]] = 'B';
                        }
                        else if (lair[positionToMultiplay[j], positionToMultiplay[j + 1]] == 'P')
                        {
                            playerDead = true;
                            break;
                        }
                    }
                }

                if (playerDead)
                {
                    break;
                }
            }
        }

        private static bool RabbitCanMultyplay(char[,]lair,int row,int col)
        {
            return row >= 0 && row < lair.GetLength(0)
                && col >= 0 && col < lair.GetLength(1);
        }

        private static List<int> GetRabbits(char[,] lair)
        {
            List<int> positions = new List<int>();

            for (int row = 0; row < lair.GetLength(0); row++)
            {
                for (int col = 0; col < lair.GetLength(1); col++)
                {
                    if (lair[row,col] == 'B')
                    {
                        positions.Add(row);
                        positions.Add(col);
                    }
                }
            }

            return positions;
        }

        private static bool IsInLair(char[,]lair,int row, int col)
        {
            return row >= 0 && row < lair.GetLength(0)
                && col >= 0 && col < lair.GetLength(1);
        }

        private static int[] GetPosition(char[,] lair)
        {
            int[] position = new int[2];

            for (int row = 0; row < lair.GetLength(0); row++)
            {
                for (int col = 0; col < lair.GetLength(1) - 1; col++)
                {
                    if (lair[row,col] == 'P')
                    {
                        position[0] = row;
                        position[1] = col;
                        break;
                    }
                }
            }

            return position;
        }

        private static void PrintLair(char[,] lair)
        {
            for (int row = 0; row < lair.GetLength(0); row++)
            {
                for (int col = 0; col < lair.GetLength(1)-1; col++)
                {
                    Console.Write($"{lair[row,col] }");
                }

                Console.WriteLine(lair[row,lair.GetLength(1)-1]);
            }
        }
    }
}
