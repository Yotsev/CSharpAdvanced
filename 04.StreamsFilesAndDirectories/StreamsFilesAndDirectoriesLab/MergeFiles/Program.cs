using System;
using System.IO;
using System.Text;

namespace MergeFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            using StreamReader firstReader = new StreamReader("FileOne.txt");
            using StreamReader secondReader = new StreamReader("FileTwo.txt");

            using StreamWriter writer = new StreamWriter("Output.txt");

            while (!firstReader.EndOfStream)
            {
                string firstLine = firstReader.ReadLine();
                string secondLine = secondReader.ReadLine();

                writer.WriteLine(firstLine);
                writer.WriteLine(secondLine);
            }
        }
    }
}
