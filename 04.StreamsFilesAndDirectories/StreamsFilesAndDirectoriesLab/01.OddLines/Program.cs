using System;
using System.IO;
using System.Threading.Tasks;

namespace _01.OddLines
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("Input.txt"))
            {
                int lineCounter = 0;
                string line = await reader.ReadLineAsync();
                
                while (line != null)
                {
                    if (lineCounter % 2 == 1)
                    {
                        Console.WriteLine(line);
                    }

                    lineCounter++;
                    line = await reader.ReadLineAsync();
                }
            }
        }
    }
}
