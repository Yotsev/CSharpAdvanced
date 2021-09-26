using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
           string[] lines = File.ReadAllLines("text.txt");

            int counter = 1;

            List<string> output = new List<string>();

            foreach (var line in lines)
            {
                int punctuationsCount = 0;
                int charCount = 0;

                foreach (var item in line)
                {
                    if (char.IsLetter(item))
                    {
                        charCount++;
                    }
                    else
                    {
                        if (!char.IsWhiteSpace(item))
                        {
                            punctuationsCount++;
                        }
                    }
                }

                StringBuilder bobTheBuilder = new StringBuilder();
                bobTheBuilder.Append($"Line {counter}: {line} ({charCount})({punctuationsCount})");
                output.Add(bobTheBuilder.ToString());
                counter++;
            }

            File.WriteAllLines("output.txt", output);

        }
    }
}
