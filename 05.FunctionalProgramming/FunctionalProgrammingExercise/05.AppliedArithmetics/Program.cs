using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            string command = Console.ReadLine();

            while (command != "end")
            {
                Func<int, int> action = GetFunction(command);

                if (command == "print")
                {
                    Action<List<int>> printNumbers = n => Console.WriteLine(string.Join(" ",n));
                    printNumbers(numbers);
                }
                else
                {
                    numbers = numbers.Select(action).ToList();
                }

                command = Console.ReadLine();
            }
        }

        private static Func<int, int> GetFunction(string command)
        {
            Func<int, int> action = n => n;

            if (command == "add")
            {
                action = n => n + 1;
            }
            else if (command == "multiply")
            {
                action = n => n * 2;
            }
            else if (command == "subtract")
            {
                action = n => n - 1;
            }

            return action;
        }
    }
}
