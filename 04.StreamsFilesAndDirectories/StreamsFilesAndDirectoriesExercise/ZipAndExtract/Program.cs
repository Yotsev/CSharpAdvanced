using System;
using System.IO.Compression;

namespace ZipAndExtract
{
    class Program
    {
        static void Main(string[] args)
        {
            ZipFile.CreateFromDirectory(@"E:\SourceZipFolder", @"E:\TargetZipFolder\file.zip");
            ZipFile.ExtractToDirectory(@"E:\TargetZipFolder\file.zip", @"E:\ResultZipFolder");
        }
    }
}
