using System;
using System.IO;

namespace CopyBinaryFile
{
    class Program
    {
        static void Main(string[] args)
        {
            using FileStream reder = new FileStream("copyMe.png",FileMode.Open,FileAccess.Read);
            byte[] buffer = new byte[4096];

            using FileStream writer = new FileStream("newImg.png", FileMode.Create, FileAccess.Write);
            reder.CopyTo(writer, buffer.Length);
        }
    }
}
