using System;

namespace CustomTuple
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string fistName = firstInput[0];
            string lastName = firstInput[1];
            string address = firstInput[2];

            string fullName = (new string($"{fistName} {lastName}"));

            CustomTuple<string, string> nameAndAddress = new CustomTuple<string, string>();
            nameAndAddress.FirstItem = fullName;
            nameAndAddress.SecondItem = address;

            string[] secondInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string name = secondInput[0];
            int litersOfBeer = int.Parse(secondInput[1]);

            CustomTuple<string, int> nameAndBeer = new CustomTuple<string, int>();
            nameAndBeer.FirstItem = name;
            nameAndBeer.SecondItem = litersOfBeer;

            string[] thirdInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int firstNumber = int.Parse(thirdInput[0]);
            double secondNumber = double.Parse(thirdInput[1]);

            CustomTuple<int, double> twoNumbers = new CustomTuple<int, double>();
            twoNumbers.FirstItem = firstNumber;
            twoNumbers.SecondItem = secondNumber;

            Console.WriteLine($"{nameAndAddress.FirstItem} -> {nameAndAddress.SecondItem}");
            Console.WriteLine($"{nameAndBeer.FirstItem} -> {nameAndBeer.SecondItem}");
            Console.WriteLine($"{twoNumbers.FirstItem} -> {twoNumbers.SecondItem}");
        }
    }
}
