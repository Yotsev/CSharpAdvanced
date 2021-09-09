using System;
using System.Collections.Generic;

namespace _08.BalancedParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> brackets = new Stack<char>();

            bool isBalanced = true;

            foreach (var item in input)
            {
                if (item == '{' || item == '[' || item == '(')
                {
                    brackets.Push(item);
                }
                else
                {
                    if (brackets.Count == 0)
                    {
                        isBalanced = false;
                        break;
                    }
                    else if (brackets.Peek() == '{' && item == '}')
                    {
                        brackets.Pop();
                    }
                    else if (brackets.Peek() == '[' && item == ']')
                    {
                        brackets.Pop();
                    }
                    else if (brackets.Peek() == '(' && item == ')')
                    {
                        brackets.Pop();
                    }
                    else
                    {
                        isBalanced = false;
                        break;
                    }
                }
            }

            if (!isBalanced)
            {
                Console.WriteLine("NO");
            }
            else
            {
                Console.WriteLine("YES");
            }
        }
    }
}
