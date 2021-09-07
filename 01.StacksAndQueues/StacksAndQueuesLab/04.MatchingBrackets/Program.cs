using System;
using System.Collections.Generic;

namespace _04.MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<int> openBraket = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    openBraket.Push(i);
                }

                if (input[i] == ')')
                {
                    Console.WriteLine(input.Substring(openBraket.Peek(),i-openBraket.Pop()+1));
                }
            }
        }
    }
}
