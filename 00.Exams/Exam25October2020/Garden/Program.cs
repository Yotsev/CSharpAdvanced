using System;
using System.Linq;
using System.Collections.Generic;

namespace Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] gardenSize = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int gardenRows = gardenSize[0];
            int gardenCols = gardenSize[1];

            string command = Console.ReadLine();

            int[][] garden = new int[gardenRows][];
            ReadGarden(gardenCols, garden);
            List<(int row, int col)> plantedFlowers = new List<(int row, int col)>();

            while (command != "Bloom Bloom Plow")
            {
                string[] commandArgs = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                int rowIndex = int.Parse(commandArgs[0]);
                int colIndex = int.Parse(commandArgs[1]);

                if (!isValidIndex(garden, rowIndex, colIndex))
                {
                    Console.WriteLine("Invalid coordinates.");
                    command = Console.ReadLine();
                    continue;
                }
                else
                {
                    garden[rowIndex][colIndex] = 1;
                    plantedFlowers.Add((rowIndex, colIndex));
                }

                command = Console.ReadLine();
            }

            BloomFlowers(garden, plantedFlowers);
            PrintGarden(garden);
        }

        private static void BloomFlowers(int[][] garden, List<(int row, int col)> plantedFlowers)
        {
            for (int i = 0; i < plantedFlowers.Count; i++)
            {
                for (int col = 0; col < garden[plantedFlowers[i].row].Length; col++)
                {
                    if (plantedFlowers[i].col == col)
                    {
                        continue;
                    }
                    garden[plantedFlowers[i].row][col]++;
                }

                for (int row = 0; row < garden[plantedFlowers[i].col].Length; row++)
                {
                    if (plantedFlowers[i].row == row)
                    {
                        continue;
                    }

                    garden[row][plantedFlowers[i].col]++;
                }
            }
        }

        private static bool isValidIndex(int[][] garden, int rowIndex, int colIndex)
        {
            if (rowIndex >= 0 && rowIndex < garden.Length && colIndex >= 0 && colIndex < garden[rowIndex].Length)
            {
                return true;
            }

            return false;
        }
        private static void PrintGarden(int[][] garden)
        {
            for (int row = 0; row < garden.Length; row++)
            {
                Console.WriteLine(string.Join(" ", garden[row]));
            }
        }
        private static void ReadGarden(int numberOfCols, int[][] garden)
        {
            for (int row = 0; row < garden.Length; row++)
            {
                garden[row] = new int[numberOfCols];

                for (int col = 0; col < garden[row].Length; col++)
                {
                    garden[row][col] = 0;
                }
            }
        }
    }
}
