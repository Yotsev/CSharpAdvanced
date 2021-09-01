using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            int divider = int.Parse(Console.ReadLine());

            Func<int, bool> filter = num => num % divider != 0;

            numbers = numbers.Where(filter).Reverse().ToList();

            Console.WriteLine(string.Join(" ",numbers));
        }
    }
}
