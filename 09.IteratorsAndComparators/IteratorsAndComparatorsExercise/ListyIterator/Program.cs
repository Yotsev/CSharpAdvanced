using System;
using System.Linq;

namespace ListyIterator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] commandArgs = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var listy = new ListyIterator<string>(commandArgs.Skip(1).ToArray());

            while (commandArgs[0] != "END")
            {
                string action = commandArgs[0];

                if (action == "Print")
                {
                    try
                    {
                        listy.Print();
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    
                }
                else if (action == "HasNext")
                {
                    Console.WriteLine(listy.HasNext());
                }
                else if (action == "Move")
                {
                    Console.WriteLine(listy.Move());
                }
                else if (action == "PrintAll")
                {
                    Console.WriteLine(string.Join(" ",listy));
                }

                commandArgs = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
        }
    }
}
