using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.PredicateParty
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, string> func;

            List<string> people = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            string command = Console.ReadLine();

            while (command != "Party!")
            {
                string[] commandArgs = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string action = commandArgs[0];
                string criteria = commandArgs[1];
                string condition = commandArgs[2];

                Predicate<string> predicate = GetPredicate(criteria, condition);

                if (action == "Double")
                {
                    List<string> names = people.FindAll(predicate);
                    if (names.Any())
                    {
                        int index = people.FindIndex(predicate);

                        people.InsertRange(index, names);
                    }
                }
                else if (action == "Remove")
                {
                    people.RemoveAll(predicate);
                }

                command = Console.ReadLine();
            }

            if (people.Count != 0)
            {
                Console.WriteLine($"{string.Join(", ", people)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        private static Predicate<string> GetPredicate(string criteriaInfo, string conditionInfo)
        {
            if (criteriaInfo == "StartsWith")
            {
                return x => x.StartsWith(conditionInfo);
            }
            else if (criteriaInfo == "EndsWith")
            {
                return x => x.EndsWith(conditionInfo);
            }

            return x => x.Length == int.Parse(conditionInfo);
        }
    }
}
