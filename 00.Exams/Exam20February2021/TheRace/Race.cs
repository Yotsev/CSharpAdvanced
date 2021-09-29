using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TheRace
{
    public class Race
    {
        private List<Racer> data;

        public Race(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.data = new List<Racer>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return this.data.Count; } }

        public void Add(Racer racer)
        {
            if (Capacity > Count)
            {
                data.Add(racer);
            }
        }

        public bool Remove(string name)
        {
            Racer racer = data.FirstOrDefault(r => r.Name == name);

            return data.Remove(racer);
        }

        public Racer GetOldestRacer()
        {
            Racer oldestRacer = data.OrderByDescending(r => r.Age).FirstOrDefault();

            return oldestRacer;
        }

        public Racer GetRacer(string name)
        {
            Racer targetRacer = data.FirstOrDefault(r => r.Name == name);

            return targetRacer;
        }

        public Racer GetFastestRacer()
        {
            Racer fastestRacer = data.OrderByDescending(r => r.Car.Speed).FirstOrDefault();

            return fastestRacer;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Racers participating at {this.Name}:");

            foreach (var racer in data)
            {
                sb.AppendLine(racer.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
