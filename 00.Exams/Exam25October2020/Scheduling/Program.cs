using System;
using System.Linq;
using System.Collections.Generic;

namespace Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] tasksInfo = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] threadsInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int taskToKill = int.Parse(Console.ReadLine());

            Queue<int> threads = new Queue<int>(threadsInfo);
            Stack<int> tasks = new Stack<int>(tasksInfo);


            while (tasks.Count > 0 && threads.Count > 0)
            {
                if (tasks.Peek() == taskToKill)
                {
                    tasks.Pop();
                    break;
                }
                else if (threads.Peek() >= tasks.Peek())
                {
                    tasks.Pop();
                    threads.Dequeue();
                }
                else if (threads.Peek() < tasks.Peek())
                {
                    threads.Dequeue();
                }
            }

            Console.WriteLine($"Thread with value {threads.Peek()} killed task {taskToKill}");
            Console.WriteLine(string.Join(" ", threads));
        }
    }
}
