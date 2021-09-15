using System;

namespace GenericBoxOfString
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int numberOfInputs = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfInputs; i++)
            {
                Box<string> box = new Box<string>();
                box.Value = Console.ReadLine();
                Console.WriteLine(box.ToString());
            }
        }
    }
}
