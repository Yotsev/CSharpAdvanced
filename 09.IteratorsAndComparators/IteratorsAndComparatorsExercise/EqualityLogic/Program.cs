using System;
using System.Collections.Generic;

namespace EqualityLogic
{
    public class Program
    {
        static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());

            SortedSet<Person> setPeople = new SortedSet<Person>();
            HashSet<Person> hashPeople = new HashSet<Person>();

            for (int i = 0; i < numberOfPeople; i++)
            {
                string[] personInfo = Console.ReadLine()
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries);

                Person currentPerson = new Person(personInfo[0], int.Parse(personInfo[1]));
                setPeople.Add(currentPerson);
                hashPeople.Add(currentPerson);
            }

            Console.WriteLine(setPeople.Count);
            Console.WriteLine(hashPeople.Count);
        }
    }
}
