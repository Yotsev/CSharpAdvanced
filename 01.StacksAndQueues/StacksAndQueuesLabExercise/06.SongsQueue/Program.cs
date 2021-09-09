using System;
using System.Collections.Generic;

namespace _06.SongsQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] songsInput = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);
            string command = Console.ReadLine();

            Queue<string> songs = new Queue<string>(songsInput);

            while (songs.Count>0)
            {
                string[] commanArgs = command
                    .Split(" ", 2,StringSplitOptions.RemoveEmptyEntries);

                string action = commanArgs[0];

                if (action == "Play")
                {
                    songs.Dequeue();
                }
                else if (action == "Add")
                {
                    string song = commanArgs[1];

                    if (!songs.Contains(song))
                    {
                        songs.Enqueue(song);
                    }
                    else
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }
                }
                else if (action == "Show")
                {
                    Console.WriteLine(string.Join(", ",songs));
                }

                command = Console.ReadLine();
            }

            Console.WriteLine("No more songs!");
        }
    }
}
