using System;
using System.Linq;

namespace _06.JaggedArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] jaggedArray = new int[rows][];

            for (int row = 0; row < jaggedArray.Length; row++)
            {
                int[] jaggedRow = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                jaggedArray[row] = jaggedRow;
            }

            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] commandArgs = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string action = commandArgs[0];
                int row = int.Parse(commandArgs[1]);
                int index = int.Parse(commandArgs[2]);
                int value = int.Parse(commandArgs[3]);

                if (row<0 
                    || row>=jaggedArray.Length
                    ||index<0 
                    || index>=jaggedArray[row].Length)
                {
                    Console.WriteLine("Invalid coordinates");

                    command = Console.ReadLine();
                    continue;
                }
                else if (action == "Add")
                {
                    jaggedArray[row][index] += value;
                }
                else if (action == "Subtract")
                {
                    jaggedArray[row][index] -= value;

                }

                command = Console.ReadLine();
            }

            for (int row = 0; row < jaggedArray.Length; row++)
            {
                Console.WriteLine(string.Join(" ",jaggedArray[row]));
            }
        }
    }
}
