using System;
using System.Collections.Generic;

namespace ImplementingQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomQueue<int> custom = new CustomQueue<int>();

            custom.Enqueue(5);
            custom.Enqueue(6);
            custom.Enqueue(6);
            custom.Enqueue(6);
            custom.Enqueue(6);
            custom.Enqueue(6);
            custom.Enqueue(6);
            custom.Enqueue(6);
            custom.Enqueue(6);
            custom.Enqueue(6);
            custom.Enqueue(6);
            custom.Enqueue(6);
            custom.Enqueue(6);
            custom.Enqueue(6);
            custom.Enqueue(6);
            custom.Enqueue(6);
            custom.Dequeue();
            custom.Dequeue();
            custom.Dequeue();
            custom.Dequeue();
            custom.Dequeue();
            custom.Dequeue();
            custom.Dequeue();
            custom.Dequeue();
            custom.Dequeue();
            custom.Dequeue();
            custom.Dequeue();
            custom.Dequeue();
        }
    }
}
