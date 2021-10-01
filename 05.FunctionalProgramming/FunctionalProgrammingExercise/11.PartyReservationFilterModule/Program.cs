using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.PartyReservationFilterModule
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            Dictionary<string, Predicate<string>> filters = new Dictionary<string, Predicate<string>>();

            string command = Console.ReadLine();

            while (command != "Print")
            {
                string[] commandArgs = command
                    .Split(";", StringSplitOptions.RemoveEmptyEntries);

                string action = commandArgs[0];
                string criteria = commandArgs[1];
                string condition = commandArgs[2];
                
                string key = $"{criteria}_{condition}";
                Predicate<string> predicate = GetPredicate(criteria, condition);

                if (action == "Add filter")
                {
                    filters.Add(key, predicate);
                }
                else if (action == "Remove filter")
                {
                    filters.Remove(key);
                }

                command = Console.ReadLine();
            }

            foreach (var filter in filters)
            {
                people.RemoveAll(filter.Value);
            }

            Console.WriteLine(string.Join(" ",people));
        }

        private static Predicate<string> GetPredicate(string criteriaInfo, string conditionInfo)
        {
            if (criteriaInfo == "Starts with")
            {
                return x => x.StartsWith(conditionInfo);
            }
            else if (criteriaInfo == "Ends with")
            {
                return x => x.EndsWith(conditionInfo);
            }
            else if (criteriaInfo == "Contains")
            {
                return x => x.Contains(conditionInfo);
            }

            return x => x.Length == int.Parse(conditionInfo);
        }
    }
}
