using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections;

namespace ListyIterator
{
    public class ListyIterator<T> :IEnumerable<T>
    {
        private readonly List<T> elements;
        private int index;

        public ListyIterator(params T[] items)
        {
            this.index = 0;
            this.elements = items.ToList();
        }

        

        public bool HasNext()
        {
            return this.index < this.elements.Count - 1;
        }

        public bool Move()
        {
            bool hasMoved = this.HasNext();

            if (hasMoved)
            {
                this.index++;
                hasMoved = true;
            }

            return hasMoved;
        }

        public void Print()
        {
            if (this.index >= this.elements.Count)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            Console.WriteLine(this.elements[this.index]);
        }
        
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < elements.Count; i++)
            {
                yield return elements[i];
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
