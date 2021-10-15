using System;
using System.Linq;

namespace StackEnumerable
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CustomStack<int> stack = new CustomStack<int>();

            string input = Console.ReadLine();
            
            while (input != "END")
            {
                string[] inputArgs = input
                    .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                string action = inputArgs[0];

                if (action == "Push")
                {
                    for (int i = 1; i < inputArgs.Length; i++)
                    {
                        stack.Push(int.Parse(inputArgs[i]));
                    }
                }
                else if (action == "Pop")
                {
                    try
                    {
                        stack.Pop();
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                input = Console.ReadLine();
            }

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(string.Join(Environment.NewLine,stack));
        }
    }
}
