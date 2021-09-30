using System;
using System.Linq

namespace PredicateParty
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] people = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string command = Console.ReadLine();                    

            while (command != "Party")
            {
                string[] commandArgs = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string action = commandArgs[0];
                string criteria = commandArgs[1];
                string filter = commandArgs[2];

                if (action == "Double")
                {
                    if (criteria == "StartsWith")
                    {

                    }
                    else if (criteria == "EndsWith")
                    {

                    }
                    else if (criteria == "Length")
                    {

                    }
                }
            }
        }
    }
}
