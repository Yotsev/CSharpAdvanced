using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            
            Func<string, int, bool> filter = (n, length) => n.Length <= length;

            Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(name => filter(name,length))
                .ToList()
                .ForEach(n => Console.WriteLine(n));
        }
    }
}
