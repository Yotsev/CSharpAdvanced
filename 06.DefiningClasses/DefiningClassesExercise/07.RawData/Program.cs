using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.RawData
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCars = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < numberOfCars; i++)
            {
                string[] carInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = carInfo[0];
                int engineSpeed = int.Parse(carInfo[1]);
                int enginePower = int.Parse(carInfo[2]);
                int cargoWeight = int.Parse(carInfo[3]);
                string cargoType = carInfo[4];

                Engine engine = new Engine()
                {
                    Speed = engineSpeed,
                    Power = enginePower
                };

                Cargo cargo = new Cargo()
                {
                    Weight = cargoWeight,
                    Type = cargoType
                };

                Tire[] tireSet = GetTireSet(carInfo);

                cars.Add(new Car(model, engine, cargo, tireSet));
            }

            string neededCargo = Console.ReadLine();

            List<Car> neededCars = new List<Car>();

            if (neededCargo == "fragile")
            {
                neededCars = cars.Where(c => c.Cargo.Type == neededCargo && c.Tires.Any(p => p.Pressure < 1)).ToList();
            }
            else if (neededCargo == "flamable")
            {
                neededCars = cars.Where(c => c.Cargo.Type == neededCargo && c.Engine.Power > 250).ToList();
            }
          
            foreach (Car car in neededCars)
            {
                Console.WriteLine(car.Model);
            }
        }
        private static Tire[] GetTireSet(string[] carInfo)
        {
            Tire[] tireSet = new Tire[4];
            List<Tire> tiers = new List<Tire>();

            for (int j = 5; j < carInfo.Length - 1; j += 2)
            {
                double pressure = double.Parse(carInfo[j]);
                int age = int.Parse(carInfo[j + 1]);

                tiers.Add(new Tire()
                {
                    Age = age,
                    Pressure = pressure
                });
            }

            tireSet = tiers.ToArray();
            return tireSet;
        }
    }
}
