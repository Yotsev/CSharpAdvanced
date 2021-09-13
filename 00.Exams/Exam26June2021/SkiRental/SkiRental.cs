using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkiRental
{
    public class SkiRental
    {
        private List<Ski> data;

        public SkiRental(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new List<Ski>();
        }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return data.Count; } }
        public void Add(Ski ski)
        {
            if (data.Count < Capacity)
            {
                data.Add(ski);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            Ski ski = data.FirstOrDefault(s => s.Manufacturer == manufacturer && s.Model == model);
            return data.Remove(ski);
        }
        public Ski GetNewestSki()
        {
            return data.OrderByDescending(s => s.Year).FirstOrDefault();
        }
        public Ski GetSki(string manufacturer, string model)
        {
            return data.FirstOrDefault(s => s.Manufacturer == manufacturer && s.Model == model);
        }
        public string GetStatistics()
        {
            StringBuilder bobTheBuilder = new StringBuilder();

            bobTheBuilder.AppendLine($"The skis stored in {Name}:");
            foreach (var item in data)
            {
                bobTheBuilder.AppendLine(item.ToString());
            }

            return bobTheBuilder.ToString();
        }
    }
}
