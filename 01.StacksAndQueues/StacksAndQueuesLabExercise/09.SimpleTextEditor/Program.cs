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


                if (action == "1")
                {
                    string stringToAdd = commadArgs[1];

                    text.Enqueue(stringToAdd);
                    editedText = text;
                }
                else if (action == "2")
                {
                    int countToRemove = int.Parse(commadArgs[1]);

                    for (int j = 0; j < countToRemove; j++)
                    {
                        editedText.Dequeue();
                    }
                }
                else if (action == "3")
                {
                    int index = int.Parse(commadArgs[1]);

                    char symbol = GetSymbol(editedText, index);
                    Console.WriteLine(symbol);
                    
                }
                else if (action == "4")
                {

                }
            }
           
        }

        private static char GetSymbol(Queue<string> editedText, int index)
        {
            for (int i = 0; i < editedText.Peek().Length; i++)
            {
                if (i == index-1)
                {
                    return editedText.Peek()[i];
                }
            }

            return '\0';
        }
    }
}
