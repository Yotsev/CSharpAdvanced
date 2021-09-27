using System;
using System.IO.Compression;

namespace ZipAndExtract
{
    class Program
    {
        static void Main(string[] args)
        {
            ZipFile.CreateFromDirectory("../../../", "../../../file.zip");
            ZipFile.ExtractToDirectory("../../../file.zip", "../../../");
        }
    }
}
