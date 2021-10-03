using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    public class Car
    {
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;
        private Engine engine;
        private Tire[] tires;
        public Car()
        {
            Make = "VW";
            Model = "Golf";
            Year = 2025;
            FuelQuantity = 200;
            FuelConsumption = 10;
        }

        public Car(string make, string model, int year)
            : this()
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption)
            : this(make, model, year)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption, Engine engine, Tire[] tieres)
            : this(make, model, year, fuelQuantity, fuelConsumption)
        {
            this.Engine = engine;
            this.Tires = tieres;
        }

        public string Make
        {
            get => this.make;
            set => this.make = value;
        }
        public string Model 
        { 
            get => this.model; 
            set => this.model = value; 
        }
        public int Year 
        { 
            get => this.year; 
            set=>this.year = value; 
        }
        public double FuelQuantity
        { 
            get=>this.fuelQuantity; 
            set=>this.fuelQuantity = value; 
        }
        public double FuelConsumption 
        { 
            get => this.fuelConsumption; 
            set=> this.fuelConsumption = value; 
        }
        public Engine Engine 
        { 
            get=>this.engine; 
            set=>this.engine=value; 
        }
        public Tire[] Tires 
        { 
            get=>this.tires; 
            set=>this.tires = value; 
        }
        public void Drive(double distance)
        {
            if (FuelQuantity - distance * (FuelConsumption / 100.0) > 0)
            {
                FuelQuantity -= distance * (FuelConsumption / 100);
            }
            else
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
        }

        public string WhoAmI()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Make: {this.Make}");
            sb.AppendLine($"Model: {this.Model}");
            sb.AppendLine($"Year: {this.Year}");
            sb.Append($"Fuel: {this.fuelQuantity:F2}");

            return sb.ToString().Trim();
        }
    }
}
