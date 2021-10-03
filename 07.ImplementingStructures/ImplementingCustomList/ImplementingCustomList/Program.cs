using System;
using System.Collections.Generic;

namespace ImplementingCustomList
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomList<string> names = new CustomList<string>();

            names.Add("Pesho");
            names.Add("Gosho");
            names.Add("Ivan");
        }
    }
}
