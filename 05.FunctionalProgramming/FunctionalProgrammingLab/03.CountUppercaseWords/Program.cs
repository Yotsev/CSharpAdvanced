using System;
using System.Linq;

namespace _03.CountUppercaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, bool> isUpperCase = w => char.IsUpper(w[0]);

            string[] UpperCaseWords = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(isUpperCase)
                .ToArray();

            foreach (var word in UpperCaseWords)
            {
                Console.WriteLine(word);
            }
        }
    }
}
