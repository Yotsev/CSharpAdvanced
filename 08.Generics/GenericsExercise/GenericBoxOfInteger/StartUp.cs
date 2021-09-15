using GenericBoxOfString;
using System;

namespace GenericBoxOfInteger
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            int numberOfIntegers = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfIntegers; i++)
            {
                Box<int> box = new Box<int>();
                box.Value = int.Parse(Console.ReadLine());
                Console.WriteLine(box);
            }
        }
    }
}
