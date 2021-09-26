using System;
using System.IO;
using System.Linq;

namespace EvenLines
{
    class Program
    {
        static void Main(string[] args)
        {
           using StreamReader reader = new StreamReader("text.txt");

            int counter = 0;

            using StreamWriter writer = new StreamWriter("output.txt");

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                line = line.Replace('-','@');
                line = line.Replace(',', '@');
                line = line.Replace('.', '@');
                line = line.Replace('!', '@');
                line = line.Replace('?', '@');
                
                string[] lineArray = line
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries).Reverse().ToArray();

                if (counter %2==0)
                {
                    string output = string.Join(" ", lineArray);
                    writer.WriteLine(output);
                }

                counter++;
            }
        }
    }
}
