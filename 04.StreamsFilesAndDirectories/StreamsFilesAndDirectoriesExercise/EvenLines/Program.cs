using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace EvenLines
{
    class Program
    {
        static void Main(string[] args)
        {
            using StreamReader reader = new StreamReader("../../../text.txt");

            int counter = 0;

            using StreamWriter writer = new StreamWriter("../../../output.txt");

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();

                if (counter % 2 == 0)
                {
                    Regex pattern = new Regex("[-,.!?]");
                    line = pattern.Replace(line, "@");
                    string[] lineArray = line
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries).Reverse().ToArray();

                    string output = string.Join(" ", lineArray);
                    writer.WriteLine(output);
                }

                counter++;
            }
        }
    }
}
