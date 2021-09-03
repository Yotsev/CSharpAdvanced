using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.CarSalesman
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfEngines = int.Parse(Console.ReadLine());

            List<Engine> engines = new List<Engine>();

            for (int i = 0; i < numberOfEngines; i++)
            {
                string[] engineInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Engine currentEngine = GetEngineInfo(engineInfo);

                engines.Add(currentEngine);
            }

            int numberOfCars = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < numberOfCars; i++)
            {
                string[] carInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Car currentCar = GetCarInfo(carInfo, engines);

                cars.Add(currentCar);
            }

            foreach (Car car in cars)
            {
                Console.WriteLine($"{car.Model}:");
                Console.WriteLine($"  {car.Engine.Model}:");
                Console.WriteLine($"    Power: {car.Engine.Power}");
                Console.WriteLine($"    Displacement: {car.Engine.Displacement}");
                Console.WriteLine($"    Efficiency: {car.Engine.Efficiency}");
                Console.WriteLine($"  Weight: {car.Weight}");
                Console.WriteLine($"  Color: {car.Color}");
            }
        }

        private static Car GetCarInfo(string[] carInfo, List<Engine> engines)
        {
            Car car = new Car();
            Engine engine = GetEngine(engines, carInfo);


            if (carInfo.Length == 2)
            {
                car = new Car()
                {
                    Model = carInfo[0],
                    Engine = engine
                };
            }
            else if (carInfo.Length == 3)
            {
                bool success = int.TryParse(carInfo[2], out _);

                if (success)
                {
                    car = new Car()
                    {
                        Model = carInfo[0],
                        Engine = engine,
                        Weight = carInfo[2]
                    };
                }
                else
                {
                    car = new Car()
                    {
                        Model = carInfo[0],
                        Engine = engine,
                        Color = carInfo[2]
                    };
                }
            }
            else
            {
                car = new Car()
                {
                    Model = carInfo[0],
                    Engine = engine,
                    Weight = carInfo[2],
                    Color = carInfo[3]
                };
            }

            return car;
        }

        private static Engine GetEngine(List<Engine> engines, string[] carInfo)
        {
            Engine engine = new Engine();
            return engine = engines.FirstOrDefault(e => e.Model == carInfo[1]);
        }

        private static Engine GetEngineInfo(string[] engineInfo)
        {
            Engine engine = new Engine();

            if (engineInfo.Length == 2)
            {
                engine = new Engine()
                {
                    Model = engineInfo[0],
                    Power = int.Parse(engineInfo[1])
                };
            }
            else if (engineInfo.Length == 3)
            {
                bool success = int.TryParse(engineInfo[2], out _);

                if (success)
                {
                    engine = new Engine()
                    {
                        Model = engineInfo[0],
                        Power = int.Parse(engineInfo[1]),
                        Displacement = engineInfo[2]
                    };
                }
                else
                {
                    engine = new Engine()
                    {
                        Model = engineInfo[0],
                        Power = int.Parse(engineInfo[1]),
                        Efficiency = engineInfo[2]
                    };
                }
            }
            else
            {
                engine = new Engine()
                {
                    Model = engineInfo[0],
                    Power = int.Parse(engineInfo[1]),
                    Displacement = engineInfo[2],
                    Efficiency = engineInfo[3]
                };
            }

            return engine;
        }
    }
}
