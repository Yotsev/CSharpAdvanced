using System;
using System.Linq;

namespace _09.Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeOfField = int.Parse(Console.ReadLine());
            string[] commands = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            char[,] field = new char[sizeOfField, sizeOfField];

            for (int row = 0; row < field.GetLength(0); row++)
            {
                char[] rows = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < field.GetLength(1); col++)
                {
                    field[row, col] = rows[col];
                }
            }

            int[] minerPosition = GetMinerPosition(field);

            int coalCount = GetCoalCount(field);
            int coalCollected = 0;

            bool isGameOver = false;
            bool isAllCoalColected = false;
            bool isCommandsover = true;

            int targetPositonRow = 0;
            int targetPositonCol = 0;

            for (int i = 0; i < commands.Length; i++)
            {
                if (commands[i] == "up")
                {
                    targetPositonRow = minerPosition[0] - 1;
                    targetPositonCol = minerPosition[1];
                }
                else if (commands[i] == "down")
                {
                    targetPositonRow = minerPosition[0] + 1;
                    targetPositonCol = minerPosition[1];
                }
                else if (commands[i] == "left")
                {
                    targetPositonRow = minerPosition[0];
                    targetPositonCol = minerPosition[1] - 1;
                }
                else if (commands[i] == "right")
                {
                    targetPositonRow = minerPosition[0];
                    targetPositonCol = minerPosition[1] + 1;
                }

                if (MinerCanMove(field, targetPositonRow, targetPositonCol))
                {
                    field[minerPosition[0], minerPosition[1]] = '*';

                    if (field[targetPositonRow, targetPositonCol] == 'e')
                    {
                        isGameOver = true;
                        isCommandsover = false;
                        field[targetPositonRow, targetPositonCol] = 's';
                        minerPosition = GetMinerPosition(field);
                        break;
                    }
                    else if (field[targetPositonRow, targetPositonCol] == 'c')
                    {
                        coalCollected++;
                        field[targetPositonRow, targetPositonCol] = 's';
                        minerPosition = GetMinerPosition(field);

                        if (IsAllCoalColected(coalCount, coalCollected))
                        {
                            isAllCoalColected = true;
                            isCommandsover = false;
                            break;
                        }
                    }
                    else if (field[targetPositonRow, targetPositonCol] == '*')
                    {
                        field[targetPositonRow, targetPositonCol] = 's';
                        field[minerPosition[0], minerPosition[1]] = '*';
                        minerPosition = GetMinerPosition(field);
                    }
                }
            }

            if (isGameOver)
            {
                Console.WriteLine($"Game over! ({minerPosition[0]}, {minerPosition[1]})");
            }
            else if (isAllCoalColected)
            {
                Console.WriteLine($"You collected all coals! ({minerPosition[0]}, {minerPosition[1]})");
            }
            else if (isCommandsover)
            {
                Console.WriteLine($"{coalCount- coalCollected} coals left. ({minerPosition[0]}, {minerPosition[1]})");
            }
        }

        private static bool MinerCanMove(char[,] field, int row, int col)
        {
            return row >= 0 && row < field.GetLength(0)
                && col >= 0 && col < field.GetLength(1);
        }
        private static bool IsAllCoalColected(int totalCoal, int coalCollected)
        {
            if (totalCoal - coalCollected == 0)
            {
                return true;
            }

            return false;
        }
        private static int GetCoalCount(char[,] field)
        {
            int coalCount = 0;
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    if (field[row, col] == 'c')
                    {
                        coalCount++;
                    }
                }
            }

            return coalCount;
        }
        private static int[] GetMinerPosition(char[,] field)
        {
            int[] positon = new int[2];

            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    if (field[row, col] == 's')
                    {
                        positon[0] = row;
                        positon[1] = col;
                        break;
                    }
                }
            }

            return positon;
        }
    }
}