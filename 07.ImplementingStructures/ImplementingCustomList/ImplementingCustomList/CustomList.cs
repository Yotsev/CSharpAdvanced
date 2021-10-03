using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementingCustomList
{
    public class CustomList<T>
    {
        private const int initialCapacity = 2;
        private T[] items;

        public CustomList()
        {
            this.items = new T[initialCapacity];
        }

        public int Count { get;private set; }

        public T this[int index]
        {
            get
            {
                if (index>=this.Count)
                {
                    throw new ArgumentOutOfRangeException();
                }

                return items[index];
            }
            set
            {
                if (index>= this.Count)
                {
                    throw new ArgumentOutOfRangeException();
                }

                items[index] = value;
            }
        }

        public void Add (T item)
        {
            if (this.Count == this.items.Length)
            {
                Resize();
            }

            items[this.Count] = item;
            Count++;
        }

        public T RemoveAt(int index)
        {
            T item;

            if (index<0 && index>=this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            item = this.items[index];
            for (int i = this.Count - 1; i >= index; i--)
            {
                this.items[i] = this.items[i - 1];
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
