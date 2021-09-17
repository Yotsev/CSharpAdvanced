using System;

namespace CustomThreeuple
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string fullName = new string($"{firstInput[0]} {firstInput[1]}");
            string address = firstInput[2];
            string town = firstInput.Length < 5 ? $"{firstInput[3]}" : $"{firstInput[3]} {firstInput[4]}";

            CustomThreeuple<string, string, string> fullNameAddressAndTown = new CustomThreeuple<string, string, string>();
            fullNameAddressAndTown.FirstItem = fullName;
            fullNameAddressAndTown.SecondItem = address;
            fullNameAddressAndTown.ThirdItem = town;

            string[] seconInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string name = seconInput[0];
            int litersOfbeer = int.Parse(seconInput[1]);
            bool isDrunk = seconInput[2] == "drunk" ? true : false;
            
            CustomThreeuple<string, int, bool> drunkPerson = new CustomThreeuple<string, int, bool>();
            drunkPerson.FirstItem = name;
            drunkPerson.SecondItem = litersOfbeer;
            drunkPerson.ThirdItem = isDrunk;

            string[] thirdInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string personsName = thirdInput[0];
            double accountBalance = double.Parse(thirdInput[1]);
            string bankName = thirdInput[2];
            
            CustomThreeuple<string, double, string> bankAccountInfo = new CustomThreeuple<string, double, string>();
            bankAccountInfo.FirstItem = personsName;
            bankAccountInfo.SecondItem = accountBalance;
            bankAccountInfo.ThirdItem = bankName;

            Console.WriteLine($"{fullNameAddressAndTown.FirstItem} -> {fullNameAddressAndTown.SecondItem} -> {fullNameAddressAndTown.ThirdItem}");
            Console.WriteLine($"{drunkPerson.FirstItem} -> {drunkPerson.SecondItem} -> {drunkPerson.ThirdItem}");
            Console.WriteLine($"{bankAccountInfo.FirstItem} -> {bankAccountInfo.SecondItem} -> {bankAccountInfo.ThirdItem}");
        }
    }
}
