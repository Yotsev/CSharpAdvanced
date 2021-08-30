using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<string, string> contests = new Dictionary<string, string>();

            while (input != "end of contests")
            {
                string[] inputInfo = input
                    .Split(":", StringSplitOptions.RemoveEmptyEntries);

                string contestName = inputInfo[0];
                string contestPassword = inputInfo[1];

                if (!contests.ContainsKey(contestName))
                {
                    contests.Add(contestName, contestPassword);
                }

                input = Console.ReadLine();
            }

            string submissions = Console.ReadLine();

            Dictionary<string, User> users = new Dictionary<string, User>();

            while (submissions != "end of submissions")
            {
                string[] submissionsInfo = submissions
                    .Split("=>", StringSplitOptions.RemoveEmptyEntries);

                string contestName = submissionsInfo[0];
                string contestPassword = submissionsInfo[1];
                string username = submissionsInfo[2];
                int points = int.Parse(submissionsInfo[3]);

                if (contests.ContainsKey(contestName) && contests[contestName] == contestPassword)
                {
                    if (!users.ContainsKey(username))
                    {
                        users.Add(username, new User(username));
                        users[username].Contests.Add(contestName, points);
                    }

                    if (!users[username].Contests.ContainsKey(contestName))
                    {
                        users[username].Contests.Add(contestName, points);
                    }
                    else
                    {
                        if (users[username].Contests[contestName]<points)
                        {
                            users[username].Contests[contestName] = points;
                        }
                    }
                }

                submissions = Console.ReadLine();
            }

            User bestCandidate = GetBestCandidate(users);

            Console.WriteLine($"Best candidate is {bestCandidate.Username} with total {bestCandidate.TotalPoints} points.");
            Console.WriteLine("Ranking:");

            foreach (var user in users.OrderBy(n => n.Key))
            {
                Console.WriteLine(user.Key);
                foreach (var contest in user.Value.Contests.OrderByDescending(p =>p.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }

        private static User GetBestCandidate(Dictionary<string, User> users)
        {
            int points = 0;
            User topUser = new User();
            foreach (var user in users)
            {
                if (user.Value.TotalPoints>points)
                {
                    topUser = user.Value;
                    points = user.Value.TotalPoints;
                }
            }

            return topUser;
        }

        class User
        {
            public User()
            {

            }
            public User(string name)
            {
                Username = name;
                Contests = new Dictionary<string, int>();
            }
            public string Username { get; set; }
            public Dictionary<string, int> Contests { get; set; }
            public int TotalPoints
            {
                get
                {
                    int points = 0;
                    foreach (var contest in Contests)
                    {
                        points += contest.Value;
                    }

                    return points;
                }
            }
        }
    }
}

