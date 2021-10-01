using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int targetSum = int.Parse(Console.ReadLine());
            List<string> people = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Func<string, int, bool> namesSum = (name, sum) => name.Sum(x => x) >= sum;

            Func<List<string>, Func<string, int, bool>, string> targetPerson = (people, namesSum) => people.FirstOrDefault(n => namesSum(n,targetSum));

            string name = targetPerson(people, namesSum);

            Console.WriteLine(name);
        }
    }
}
