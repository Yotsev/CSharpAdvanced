using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string tire = Console.ReadLine();

            List<Tire[]> tireSets = new List<Tire[]>();

            while (tire != "No more tires")
            {
                string[] tireInfo = tire
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                List<Tire> set = new List<Tire>();

                for (int i = 0; i < tireInfo.Length - 1; i += 2)
                {
                    int year = int.Parse(tireInfo[i]);
                    double pressure = double.Parse(tireInfo[i + 1]);
                    set.Add(new Tire(year, pressure));
                }

                tireSets.Add(set.ToArray());
                set.Clear();

                tire = Console.ReadLine();
            }

            string engine = Console.ReadLine();

            List<Engine> engines = new List<Engine>();

            while (engine != "Engines done")
            {
                string[] engineInfo = engine
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                int horsePower = int.Parse(engineInfo[0]);
                double cubicCapacity = double.Parse(engineInfo[1]);

                engines.Add(new Engine(horsePower, cubicCapacity));

                engine = Console.ReadLine();
            }

            string specialCar = Console.ReadLine();

            List<Car> cars = new List<Car>();

            while (specialCar != "Show special")
            {
                string[] specialCarInfo = specialCar
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string make = specialCarInfo[0];
                string model = specialCarInfo[1];
                int year = int.Parse(specialCarInfo[2]);
                double fuelQuantity = double.Parse(specialCarInfo[3]);
                double fuelConsumption = double.Parse(specialCarInfo[4]);
                int engineIndex = int.Parse(specialCarInfo[5]);
                int tiresIndex = int.Parse(specialCarInfo[6]);

                cars.Add(new Car(make, model, year, fuelQuantity, fuelConsumption, engines[engineIndex], tireSets[tiresIndex]));

                specialCar = Console.ReadLine();
            }

            foreach (Car car in cars)
            {
                double sumOftiersPressure = GetTiresPresure(car);

                if (car.Year >= 2017 && car.Engine.HorsePower >= 330 && sumOftiersPressure >= 9 && sumOftiersPressure <= 10)
                {
                    car.Drive(20);
                    Console.WriteLine($"Make: {car.Make}\nModel: {car.Model}\nYear: {car.Year}\nHorsePower: {car.Engine.HorsePower}\nFuelQuantity: {car.FuelQuantity}");
                }
            }
        }

        private static double GetTiresPresure(Car car)
        {
            double sum = 0;

            foreach (Tire tire in car.Tires)
            {
                sum += tire.Pressure;
            }

            return sum;
        }
    }
}
