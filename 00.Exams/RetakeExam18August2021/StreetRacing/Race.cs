using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreetRacing
{
    public class Race
    {
        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            this.Name = name;
            this.Type = type;
            this.Laps = laps;
            this.Capacity = capacity;
            this.MaxHorsePower = maxHorsePower;
            this.Participants = new List<Car>();
        }

        public List<Car> Participants { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Laps { get; set; }
        public int Capacity { get; set; }
        public int MaxHorsePower { get; set; }
        public int Count { get { return this.Participants.Count; } }

        public void Add(Car car)
        {
            if (!Participants.Contains(car) && Capacity >= Count && car.HorsePower <= this.MaxHorsePower)
            {
                Participants.Add(car);
            }
        }

        public bool Remove(string licensePlate)
        {
            Car car = Participants.FirstOrDefault(c => c.LicensePlate == licensePlate);
            
            return Participants.Remove(car);
        }

        public Car FindParticipant(string licensePlate)
        {
            Car car = Participants.FirstOrDefault(c => c.LicensePlate == licensePlate);

            return car;
        }

        public Car GetMostPowerfulCar()
        {
            Car car = Participants.OrderByDescending(c => c.HorsePower).FirstOrDefault();

            return car;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Race: {this.Name} - Type: {this.Type} (Laps: {this.Laps})");
            foreach (Car car in Participants)
            {
                sb.AppendLine(car.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
