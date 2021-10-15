using System;
using System.Collections.Generic;

namespace ComparingObjects
{
    public class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<Person> people = new List<Person>();

            while (input != "END")
            {
                string[] inputArgs = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                people.Add(new Person(inputArgs[0], int.Parse(inputArgs[1]), inputArgs[2]));

                input = Console.ReadLine();
            }

            int targetPurson = int.Parse(Console.ReadLine());

            int matches = 0;
            int distinct = 0;

            for (int i = 0; i < people.Count; i++)
            {
                if (people[targetPurson-1].CompareTo(people[i]) == 0)
                {
                    matches++;
                }
                else
                {
                    distinct++;
                }
            }

            if (matches<=1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{matches} {distinct} {people.Count}");
            }
        }
    }
}
