using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.ActionPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> print = msg => Console.WriteLine(msg);

            Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList().ForEach(x => print(x));
        }
    }
}
