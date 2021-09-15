using System;
using System.Collections.Generic;
using System.Text;

namespace _07.RawData
{
    public class Car
    {
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }
        public Tire[] Tires { get; set; }

        public Car(string model, Engine engine, Cargo cargo, Tire[] tires)
        {
            Model = model;
            Engine = new Engine();
            Engine = engine;
            Cargo = new Cargo();
            Cargo = cargo;
            Tires = new Tire[4];
            Tires = tires;
        }
    }
}
