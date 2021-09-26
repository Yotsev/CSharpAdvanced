using System;
using System.IO;

namespace OddLines
{
    class Program
    {
        static void Main(string[] args)
        {
            using StreamReader reader = new StreamReader("Input.txt");

            int counter = 0;

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();

                if (counter%2==1)
                {
                    Console.WriteLine(line);
                }

                counter++;
            }
        }
    }
}
