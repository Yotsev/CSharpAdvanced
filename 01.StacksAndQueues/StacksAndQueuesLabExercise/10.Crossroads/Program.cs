using System;
using System.Collections.Generic;

namespace _10.Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLight = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();

            Queue<string> cars = new Queue<string>();

            bool crashHappend = false;
            char crashedChar = '\0';
            int passedCars = 0;


            while (command != "END")
            {
                int currentGreenLight = greenLight;

                if (command == "green")
                {
                    while (currentGreenLight > 0 && cars.Count > 0)
                    {
                        if (cars.Peek().Length <= currentGreenLight)
                        {
                            currentGreenLight -= cars.Dequeue().Length;
                            passedCars++;
                        }
                        else
                        {
                            if (cars.Peek().Length-currentGreenLight<=freeWindow)
                            {
                                currentGreenLight -= cars.Dequeue().Length;
                                passedCars++;
                            }
                            else
                            {
                                crashedChar = cars.Peek()[currentGreenLight + freeWindow];
                                crashHappend = true;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    cars.Enqueue(command);
                }

                if (crashHappend)
                {
                    break;
                }

                command = Console.ReadLine();
            }

            if (crashHappend)
            {
                Console.WriteLine("A crash happened!");
                Console.WriteLine($"{cars.Peek()} was hit at {crashedChar}.");
            }
            else
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{passedCars} total cars passed the crossroads.");
            }
        }
    }
}
