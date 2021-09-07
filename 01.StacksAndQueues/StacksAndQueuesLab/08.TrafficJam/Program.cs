using System;
using System.Collections.Generic;

namespace _08.TrafficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCarsToPass = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();

            Queue<string> cars = new Queue<string>();

            int passedCars = 0;

            while (command != "end")
            {
                if (command == "green")
                {
                    for (int i = 0; i < numberOfCarsToPass; i++)
                    {
                        if (cars.Count > 0)
                        {
                            Console.WriteLine($"{cars.Dequeue()} passed!");
                            passedCars++;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                else
                {
                    cars.Enqueue(command);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"{passedCars} cars passed the crossroads.");
        }
    }
}
