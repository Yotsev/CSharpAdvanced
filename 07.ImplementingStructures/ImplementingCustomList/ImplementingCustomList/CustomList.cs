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

        public int Count { get; private set; }

        public CustomList()
        {
            this.items = new T[initialCapacity];
        }

        public T this[int index]
        {
            get
            {
                if (index >= Count)
                {
                    throw new ArgumentOutOfRangeException();
                }

                return this.items[index];
            }
            set
            {
                if (index >= Count)
                {
                    throw new ArgumentOutOfRangeException();
                }

                this.items[index] = value;
            }
        }

        public void Add(T element)
        {
            if (this.Count == this.items.Length)
            {
                this.Resize();
            }

            this.items[this.Count] = element;
            this.Count++;
        }
        public T RemoveAt(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            T item = this.items[index];
            this.items[index] = default(T);
            this.ShiftToLeft(index);
            
            this.Count--;

            if (this.Count <= this.items.Length / 4)
            {
                this.Shrink();
            }

            return item;
        }
        public void Insert(int index, T item)
        {
            if (index <0 || index>=this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (this.Count == this.items.Length)
            {
                this.Resize();
            }

            this.ShiftToRight(index);
            this.items[index] = item;
            this.Count++;
        }
        public bool Contains(int element)
        {
            bool isContained = false;

            for (int i = 0; i <= this.Count; i++)
            {
                if (this.items[i].Equals(element))
                {
                    isContained = true;
                }
            }

            return isContained;
        }
        private void Resize()
        {
            T[] copy = new T[initialCapacity * 2];

            for (int i = 0; i < this.items.Length; i++)
            {
                copy[i] = this.items[i];
            }

            this.items = copy;
        }

        private void ShiftToLeft(int index)
        {
            for (int i = index; i < this.Count - 1; i++)
            {
                this.items[i] = this.items[i + 1];
            }
        }

        private void Shrink()
        {
            T[] copy = new T[this.items.Length / 2];

            for (int i = 0; i < this.Count; i++)
            {
                copy[i] = this.items[i];
            }

            this.items = copy;
        }

        private void ShiftToRight(int index)
        {
            for (int i = Count ; i > index; i--)
            {
                this.items[i] = this.items[i - 1];
            }
        }
    }
}


