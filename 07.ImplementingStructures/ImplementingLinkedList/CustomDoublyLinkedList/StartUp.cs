using System;

namespace CustomDoublyLinkedList
{
    class StartUp
    {
        static void Main(string[] args)
        {
            CustomDoubleLinkedList list = new CustomDoubleLinkedList();

            list.AddFirst(5);

            list.ForEach(n => Console.WriteLine(n));
        }
    }
}
