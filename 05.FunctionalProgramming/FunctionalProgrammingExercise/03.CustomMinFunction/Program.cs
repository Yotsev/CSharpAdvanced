using System;
using System.Linq;

namespace _03.CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {

            Func<int[], int> smallestNumber = num => num.Min();

            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int result = smallestNumber(numbers);

            Console.WriteLine(result);
        }
    }
}
