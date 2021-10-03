using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementingCustomStack
{
    public class CustomStack<T>
    {
        private const int initialCapacity = 4;
        private T[] items;
        private int count;

        public CustomStack()
        {
            this.count = 0;
            this.items = new T[initialCapacity];
        }

        public int Count { get { return this.count; } }

        public void Push(T element)
        {
            if (this.count == this.items.Length)
            {
                this.Resize();
            }

            this.items[this.count] = element;
            this.count++;
        }

        public T Pop()
        {
            if (this.items.Length == 0)
            {
                throw new InvalidOperationException();
            }

            T item = items[this.count-1];
            items[this.count - 1] = default(T);
            this.count--;

            return item;
        }

        public T Peek()
        {
            if (this.items.Length == 0)
            {
                throw new InvalidOperationException();
            }

            T item = items[this.count - 1];
            
            return item;
        }


        public void ForEach(Action<T> action)
        {
            for (int i = 0; i < this.count; i++)
            {
                action(this.items[i]);
            }
        }
        private void Resize()
        {
            T[] copy = new T[this.items.Length * 2];

            for (int i = 0; i < this.items.Length; i++)
            {
                copy[i] = this.items[i];
            }

            this.items = copy;
        }
    }
}
