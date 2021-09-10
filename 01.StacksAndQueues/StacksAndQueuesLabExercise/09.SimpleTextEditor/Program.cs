using System;
using System.Text;
using System.Collections.Generic;

namespace _09.SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfOperations = int.Parse(Console.ReadLine());

            StringBuilder text = new StringBuilder();
            Stack<string> previousTextState = new Stack<string>();

            for (int i = 0; i < numberOfOperations; i++)
            {
                string[] command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string action = command[0];

                if (action == "1")
                {
                    previousTextState.Push(text.ToString());
                    string textToApend = command[1];
                    text.Append(textToApend);
                }
                else if (action == "2")
                {
                    previousTextState.Push(text.ToString());
                    int numberOfElementsToRemove = int.Parse(command[1]);
                    text.Remove(text.Length - numberOfElementsToRemove, numberOfElementsToRemove);
                }
                else if (action == "3")
                {
                    int index = int.Parse(command[1]);
                    string charToShow = text.ToString().Substring(index-1,1);
                    Console.WriteLine(charToShow);
                }
                else if (action == "4")
                {
                    text.Clear().Append(previousTextState.Pop());
                }
            }
        }
    }
}
