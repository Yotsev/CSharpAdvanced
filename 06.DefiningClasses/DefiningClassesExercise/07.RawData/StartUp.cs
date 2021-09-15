using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.RawData
{
    public class StartUp
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

                Tire[] tireSet = new Tire[4];
                int counter = 0;
                for (int j = 5; j < carInfo.Length-1; j+=2)
                {
                    Tire tire = new Tire() { Pressure = double.Parse(carInfo[j]), Age = int.Parse(carInfo[j + 1])};
                    tireSet[counter] = tire;
                    counter++;
                }

                Car car = new Car(model, engine, cargo, tireSet);

                cars.Add(car);
            }

            string neededCargo = Console.ReadLine();

            List<Car> filteredCars = new List<Car>();
            
            if (neededCargo == "fragile")
            {
                filteredCars = cars.Where(c => c.Cargo.Type == neededCargo && c.Tires.Any(t => t.Pressure < 1)).ToList();
            }
            else if (neededCargo == "flammable")
            {
                filteredCars = cars.Where(c => c.Cargo.Type == neededCargo && c.Engine.Power > 250).ToList();
            }

            foreach (Car car in filteredCars)
            {
                Console.WriteLine(car.Model);
            }
        }
    }
}
