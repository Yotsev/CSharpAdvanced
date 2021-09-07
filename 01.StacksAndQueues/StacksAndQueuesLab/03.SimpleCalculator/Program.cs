using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                

            Stack<string> calculator = new Stack<string>(input.Reverse());

            while (calculator.Count>1)
            {
                int firstNumber = int.Parse(calculator.Pop());
                string sign = calculator.Pop();
                int secondNumber = int.Parse(calculator.Pop());

                if (sign == "+")
                {
                    calculator.Push((firstNumber + secondNumber).ToString());
                }
                else
                {
                    calculator.Push((firstNumber - secondNumber).ToString());
                }
            }

            Console.WriteLine(calculator.Pop());
        }
    }
}
