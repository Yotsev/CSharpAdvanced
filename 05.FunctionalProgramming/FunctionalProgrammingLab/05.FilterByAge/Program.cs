using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FilterByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<(string name, int age), int, bool> younger = (person, age) => person.age < age;
            Func<(string name, int age), int, bool> older = (person, age) => person.age >= age;

            int numberOfPeople = int.Parse(Console.ReadLine());
            List<(string name, int age)> people = new List<(string name, int age)>();

            for (int i = 0; i < numberOfPeople; i++)
            {
                string[] peopleInfo = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string name = peopleInfo[0];
                int age = int.Parse(peopleInfo[1]);

                people.Add((name, age));
            }

            string condition = Console.ReadLine();
            int filter = int.Parse(Console.ReadLine());
            string[] outputFormat = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            if (condition == "younger")
            {
                people = people.Where(p => younger(p,filter)).ToList();
            }
            else if (condition == "older")
            {
                people = people.Where(p => older(p, filter)).ToList();
            }

            foreach (var person in people)
            {
                List<string> output = new List<string>();
                if (outputFormat.Contains("name"))
                {
                    output.Add(person.name);
                }

                if (outputFormat.Contains("age"))
                {
                    output.Add(person.age.ToString());
                }

                Console.WriteLine(string.Join(" - ",output));
            }
        }
    }
}
