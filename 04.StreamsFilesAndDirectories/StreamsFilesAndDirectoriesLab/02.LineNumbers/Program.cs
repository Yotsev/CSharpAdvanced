using System;
using System.IO;
using System.Threading.Tasks;

namespace _02.LineNumbers
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("Input.txt"))
            {
                string line = await reader.ReadLineAsync();

                using (StreamWriter writer = new StreamWriter("Output.txt"))
                {
                    int lineCounter = 1;

                    while (line != null)
                    {
                        await writer.WriteLineAsync($"{lineCounter}. {line}");
                        lineCounter++;
                        
                        line = await reader.ReadLineAsync();
                    }
                }
            }
        }
    }
}
