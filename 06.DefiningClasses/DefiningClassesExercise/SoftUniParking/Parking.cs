using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;
        private readonly int capacity;

        public Parking(int capacity)
        {
            this.capacity = capacity;
            cars = new List<Car>();
        }

        public int Count { get { return cars.Count; } }

        public string AddCar(Car car)
        {

            Car exsistingCar = cars.FirstOrDefault(c => c.RegistrationNumber == car.RegistrationNumber);

            if (exsistingCar != null)
            {
                return "Car with that registration number, already exists!";
            }

            if (cars.Count >= capacity)
            {
                return "Parking is full!";
            }

            cars.Add(car);
            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }

        public string RemoveCar(string registrationNumber)
        {
            Car car = cars.FirstOrDefault(c => c.RegistrationNumber == registrationNumber);

            if (car == null)
            {
                return "Car with that registration number, doesn't exist!";
            }

            cars.Remove(car);

            return $"Successfully removed {car.RegistrationNumber}";
        }

        public Car GetCar(string registrationNumber)
        {
            Car car = cars.FirstOrDefault(c => c.RegistrationNumber == registrationNumber);

            return car;
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (string regNumber in registrationNumbers)
            {
                Car existingCar = cars.FirstOrDefault(c => c.RegistrationNumber == regNumber);

                if (existingCar != null)
                {
                    cars.Remove(existingCar);
                }
            }
        }
    }
}
