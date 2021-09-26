using System;
using System.IO;

namespace SliceAFile
{
    class Program
    {
        static void Main(string[] args)
        {
            using FileStream fileReader = new FileStream("sliceMe.txt", FileMode.Open);

            int newFilesSize = (int)Math.Ceiling(fileReader.Length / 4.0);

            for (int i = 1; i <= 4; i++)
            {
                var buffer = new byte[newFilesSize];

                fileReader.Read(buffer, 0, buffer.Length);

                using FileStream writer = new FileStream($"Paret-{i}.txt", FileMode.Create);
                writer.Write(buffer, 0, buffer.Length);
            }
        }
    }
}
