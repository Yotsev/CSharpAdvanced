using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.StackSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            string command = Console.ReadLine();

            Stack<int> numbers = new Stack<int>(input);

            while (command.ToUpper() != "END")
            {
                string[] commandArgs = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string action = commandArgs[0].ToUpper();

                if (action == "ADD")
                {
                    int firstNumber = int.Parse(commandArgs[1]);
                    int secondNumber = int.Parse(commandArgs[2]);

                    numbers.Push(firstNumber);
                    numbers.Push(secondNumber);
                }
                else if (action == "REMOVE")
                {
                    int countToRemove = int.Parse(commandArgs[1]);

                    if (countToRemove>numbers.Count)
                    {
                        command = Console.ReadLine();
                        continue;
                    }

                    for (int i = 0; i < countToRemove; i++)
                    {
                        numbers.Pop();
                    }
                }

                command = Console.ReadLine();
            }

            int sum = 0;

            while (numbers.Count>0)
            {
                sum += numbers.Pop();
            }

            Console.WriteLine($"Sum: {sum}");
        }
    }
}
