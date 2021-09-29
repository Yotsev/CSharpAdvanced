using System;
using System.Collections.Generic;
using System.Linq;

namespace TheFightForGondor
{
    class Program
    {
        static void Main(string[] args)
        {
            int wavesOfOrcs = int.Parse(Console.ReadLine());

            Queue<int> platesOfTheAragornsDefence = new Queue<int>(Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray());

            Stack<int> warriorOrcsLeft = new Stack<int>();
            bool isTheDefenceOfGondorDestroyed = false;

            for (int i = 1; i <= wavesOfOrcs; i++)
            {
                Stack<int> newWaveOrcs = new Stack<int>(Console.ReadLine()
                    .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray());

                if (i % 3 == 0)
                {
                    int additionalPlate = int.Parse(Console.ReadLine());
                    platesOfTheAragornsDefence.Enqueue(additionalPlate);
                }

                while (newWaveOrcs.Count != 0 && platesOfTheAragornsDefence.Count != 0)
                {
                    if (newWaveOrcs.Peek() > platesOfTheAragornsDefence.Peek())
                    {
                        newWaveOrcs.Push(newWaveOrcs.Pop() - platesOfTheAragornsDefence.Dequeue());
                    }
                    else if (platesOfTheAragornsDefence.Peek() > newWaveOrcs.Peek())
                    {
                        Queue<int> updatedPlatesOfTheAragornsDefence = new Queue<int>();

                        updatedPlatesOfTheAragornsDefence.Enqueue(platesOfTheAragornsDefence.Dequeue() - newWaveOrcs.Pop());

                        for (int j = 0; j < platesOfTheAragornsDefence.Count; j++)
                        {
                            updatedPlatesOfTheAragornsDefence.Enqueue(platesOfTheAragornsDefence.ElementAt(j));
                        }

                        platesOfTheAragornsDefence = updatedPlatesOfTheAragornsDefence;
                    }
                    else
                    {
                        platesOfTheAragornsDefence.Dequeue();
                        newWaveOrcs.Pop();
                    }

                    if (platesOfTheAragornsDefence.Count == 0)
                    {
                        isTheDefenceOfGondorDestroyed = true;
                        warriorOrcsLeft = newWaveOrcs;
                        break;
                    }
                }
            }

            if (isTheDefenceOfGondorDestroyed)
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                Console.WriteLine($"Orcs left: {string.Join(", ", warriorOrcsLeft)}");
            }
            else
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");
                Console.WriteLine($"Plates left: {string.Join(", ", platesOfTheAragornsDefence)}");
            }
        }
    }
}