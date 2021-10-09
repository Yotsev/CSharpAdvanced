using System;
using System.Collections.Generic;

namespace ImplementingQueue
{
    public class CustomQueue<T>
    {
        private const int InitialCapacity = 4;
        private const int FirstElementIndex = 0;
        private int count;

        private T[] items;

        public CustomQueue()
        {
            this.items = new T[InitialCapacity];
            this.count = 0;
        }

        public int Count => this.count;


        public void Enqueue(T element)
        {
            if (this.count == items.Length)
            {
                this.Resize();
            }

            items[count] = element;
            this.count++;
        }

        public T Dequeue()
        {
            this.IsEmpty();
            this.count--;
            T firstElement = items[FirstElementIndex];
            this.SwitchElements();
            return firstElement;
        }

        public T Peek()
        {
            this.IsEmpty();
            T firstElement = items[FirstElementIndex];

            return firstElement;
        }

        public void Clear()
        {
            this.IsEmpty();
            this.items = new T[InitialCapacity];
            this.count = 0;
        }

        public void ForEach(Action<T> action)
        {
            for (int i = 0; i < this.count; i++)
            {
                action(this.items[i]);
            }
        }

        private void SwitchElements()
        {
            this.items[FirstElementIndex] = default(T);

            for (int i = 1; i < items.Length; i++)
            {
                this.items[i - 1] = this.items[i];
            }

            this.items[this.items.Length - 1] = default(T);
        }

        private void IsEmpty()
        {
            if (this.count == 0)
            {
                throw new InvalidOperationException("The queue is empty");
            }
        }

        private T[] Resize()
        {
            T[] copyItems = new T[this.items.Length * 2];

            for (int i = 0; i < this.items.Length; i++)
            {
                copyItems[i] = this.items[i];
            }

            this.items = copyItems;

            return this.items;
        }
    }
}
