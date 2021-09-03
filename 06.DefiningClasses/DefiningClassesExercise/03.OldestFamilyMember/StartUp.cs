using System;

namespace DefiningClasses
{
   public class StartUp
    {
       public static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());

            Family family = new Family();

            for (int i = 0; i < numberOfPeople; i++)
            {
                string[] peopleInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = peopleInfo[0];
                int age = int.Parse(peopleInfo[1]);

                Person person = new Person(name, age);
                family.AddMember(person);
            }

            Person oldestMember = family.GetOldestMember();

            Console.WriteLine(oldestMember);
        }
    }
}
