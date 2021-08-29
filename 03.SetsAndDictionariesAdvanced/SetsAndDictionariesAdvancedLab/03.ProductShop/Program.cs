using System;
using System.Collections.Generic;

namespace _03.ProductShop
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            SortedDictionary<string, Dictionary<string, double>> stores = new SortedDictionary<string, Dictionary<string, double>>();

            while (command != "Revision")
            {
                string[] storeInfo = command
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string store = storeInfo[0];
                string product = storeInfo[1];
                double price = double.Parse(storeInfo[2]);

                if (!stores.ContainsKey(store))
                {
                    stores.Add(store, new Dictionary<string, double>());
                }

                stores[store].Add(product, price);

                command = Console.ReadLine();
            }

            foreach (var store in stores)
            {
                Console.WriteLine($"{store.Key}->");

                foreach (var product in store.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
