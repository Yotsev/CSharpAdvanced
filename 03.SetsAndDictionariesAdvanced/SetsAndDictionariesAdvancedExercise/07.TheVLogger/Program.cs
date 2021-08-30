using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TheVLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<string, Vloger> vlogers = new Dictionary<string, Vloger>();

            while (input != "Statistics")
            {
                string[] inputInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string vlogerName = inputInfo[0];

                if (input.Contains("joined"))
                {
                    if (!vlogers.ContainsKey(vlogerName))
                    {
                        vlogers.Add(vlogerName,new Vloger(vlogerName));
                    }
                }
                else if (input.Contains("followed"))
                {
                    string followedVloger = inputInfo[2];

                    if (vlogers.ContainsKey(vlogerName) && vlogers.ContainsKey(followedVloger))
                    {
                        if (vlogerName == followedVloger)
                        {
                            input = Console.ReadLine();
                            continue;
                        }

                        vlogers[vlogerName].Following.Add(followedVloger);
                        vlogers[followedVloger].Followers.Add(vlogerName);
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"The V-Logger has a total of {vlogers.Count} vloggers in its logs.");

            Dictionary<string, Vloger> sortedVlogers = vlogers
                .OrderByDescending(x => x.Value.Followers.Count)
                .ThenBy(f => f.Value.Following.Count)
                .ToDictionary(x => x.Key, x => x.Value);

            int count = 1;

            foreach (var vloger in sortedVlogers)
            {
                if (count == 1)
                {
                    Console.WriteLine($"{count}. {vloger.Key} : {vloger.Value.Followers.Count} followers, {vloger.Value.Following.Count} following");
                    if (vloger.Value.Followers.Count > 0)
                    {
                        foreach (var follower in vloger.Value.Followers.OrderBy(x => x))
                        {
                            Console.WriteLine($"*  {follower}");
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"{count}. {vloger.Key} : {vloger.Value.Followers.Count} followers, {vloger.Value.Following.Count} following");
                }
                
                count++;
            }
        }

        class Vloger
        {
            public Vloger(string name)
            {
                Name = name;
                Followers = new HashSet<string>();
                Following = new HashSet<string>();
            }
            public string Name { get; set; }
            public HashSet<string> Followers { get; set; }
            public HashSet<string> Following { get; set; }
        }
    }
}
