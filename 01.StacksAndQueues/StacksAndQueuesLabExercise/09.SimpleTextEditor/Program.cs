using System;
using System.Collections.Generic;

namespace _09.SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfOperations = int.Parse(Console.ReadLine());

            Queue<string> text = new Queue<string>();
            Queue<string> editedText = new Queue<string>();

            for (int i = 0; i < numberOfOperations; i++)
            {
                string[] commadArgs = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string action = commadArgs[0];

            }
           
        }
    }
}
