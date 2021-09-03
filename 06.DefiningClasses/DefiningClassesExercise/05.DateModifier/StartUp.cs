using System;

namespace DefiningClasses
{
    class StartUp
    {
        static void Main(string[] args)
        {
            DateTime firstDate = DateTime.Parse(Console.ReadLine());
            DateTime seconDate = DateTime.Parse(Console.ReadLine());

            double differens = DateModifier.DifferemceBetweenTwoDates(firstDate, seconDate);

            Console.WriteLine(differens);
        }
    }
}
