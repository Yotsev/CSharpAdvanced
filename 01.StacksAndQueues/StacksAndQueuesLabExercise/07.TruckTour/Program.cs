using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPetrolPumps = int.Parse(Console.ReadLine());

            Queue<(int petrolAmount, int distence)> pumpsInfo = new Queue<(int petrolAmount, int distence)>();


            for (int i = 0; i < numberOfPetrolPumps; i++)
            {
                int[] pump = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                pumpsInfo.Enqueue((pump[0], pump[1]));
            }

            int startingPump = 0;

            while (true)
            {
                int travelDistace = 0;

                foreach (var pump in pumpsInfo)
                {
                    (int petrol, int distance) currentPump = pump;

                    travelDistace += currentPump.petrol - currentPump.distance;
                   
                    if (travelDistace < 0)
                    {
                        pumpsInfo.Enqueue(pumpsInfo.Dequeue());
                        startingPump++;
                        break;
                    }
                }

                if (travelDistace >= 0)
                {
                    break;
                }
            }

            Console.WriteLine(startingPump);
        }
    }
}
