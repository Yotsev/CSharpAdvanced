using System;
using System.Collections.Generic;

namespace _01.ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();
            
            Stack<char> reversedInput = new Stack<char>(input);

            while (reversedInput.Count>0)
            {
                Console.Write(reversedInput.Pop());
            }
        }
    }
}
