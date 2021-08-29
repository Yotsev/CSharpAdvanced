using System;
using System.Collections.Generic;

namespace _07.SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            bool partyStarted = false;
            HashSet<string> vips = new HashSet<string>();
            HashSet<string> regulars = new HashSet<string>();

            while (command != "END")
            {
                if (command == "PARTY")
                {
                    partyStarted = true;

                    command = Console.ReadLine();
                    continue;
                }

                if (partyStarted)
                {
                    if (Char.IsDigit(command[0]))
                    {
                        vips.Remove(command);
                    }
                    else
                    {
                        regulars.Remove(command);
                    }
                }
                else
                {
                    if (Char.IsDigit(command[0]))
                    {
                        vips.Add(command);
                    }
                    else
                    {
                        regulars.Add(command);
                    }
                }

                command = Console.ReadLine();
            }


            Console.WriteLine(vips.Count+regulars.Count);

            foreach (var vip in vips)
            {
                Console.WriteLine(vip);
            }

            foreach (var regular in regulars)
            {
                Console.WriteLine(regular);
            }
        }
    }
}
