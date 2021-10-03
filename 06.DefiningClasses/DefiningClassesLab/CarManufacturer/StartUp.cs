using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string tiresCommand = Console.ReadLine();

            List<Tire[]> tireSets = new List<Tire[]>();

            while (tiresCommand != "No more tires")
            {
                string[] tiresInfo = tiresCommand
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                List<Tire> currentSet = new List<Tire>();

                for (int i = 0; i < tiresInfo.Length - 1; i += 2)
                {
                    int year = int.Parse(tiresInfo[i]);
                    double pressure = double.Parse(tiresInfo[i + 1]);

                    Tire currentTire = new Tire(year, pressure);
                    currentSet.Add(currentTire);
                }

                tireSets.Add(currentSet.ToArray());

                tiresCommand = Console.ReadLine();
            }

            string enginesCommand = Console.ReadLine();

            List<Engine> engines = new List<Engine>();

            while (enginesCommand != "Engines done")
            {
                string[] engineInfo = enginesCommand
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                int horsePower = int.Parse(engineInfo[0]);
                double cubicCapacity = double.Parse(engineInfo[1]);

                Engine currentEngine = new Engine(horsePower, cubicCapacity);

                engines.Add(currentEngine);

                enginesCommand = Console.ReadLine();
            }

            string carsCommand = Console.ReadLine();

            List<Car> cars = new List<Car>();

            while (carsCommand != "Show special")
            {
                string[] carInfo = carsCommand
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string make = carInfo[0];
                string model = carInfo[1];
                int year = int.Parse(carInfo[2]);
                double fuelQuantity = double.Parse(carInfo[3]);
                double fuelConsumption = double.Parse(carInfo[4]);
                Engine engine = engines[int.Parse(carInfo[5])];
                Tire[] tires = tireSets[int.Parse(carInfo[6])];

                Car currentCar = new Car(make, model, year, fuelQuantity, fuelConsumption, engine, tires);

                cars.Add(currentCar);

                carsCommand = Console.ReadLine();
            }

            List<Car> specialCars = cars.Where
                (c => c.Year >= 2017
                && c.Engine.HorsePower > 330
                && c.Tires.Sum(t => t.Pressure) > 9
                && c.Tires.Sum(t => t.Pressure) < 10)
                .ToList();

            foreach (var car in specialCars)
            {
                car.Drive(20);
                Console.WriteLine($"Make: {car.Make}{Environment.NewLine}Model: {car.Model}{Environment.NewLine}Year: {car.Year}{Environment.NewLine}HorsePowers: {car.Engine.HorsePower}{Environment.NewLine}FuelQuantity: {car.FuelQuantity}");
            }
        }
    }
}
