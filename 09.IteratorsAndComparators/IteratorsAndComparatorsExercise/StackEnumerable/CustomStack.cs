using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace StackEnumerable
{
    public class CustomStack<T> : IEnumerable<T>
    {
        private List<T> items;

        public CustomStack()
        {
            this.items = new List<T>();
        }

        public CustomStack(List<T> items)
        {
            this.items = items;
        }

        public void Push(T element)
        {
            this.items.Add(element);
        }

        public T Pop()
        {

            if (this.items.Count == 0)
            {
                throw new InvalidOperationException("No elements");
            }

            T element = this.items[this.items.Count - 1];
            this.items.RemoveAt(this.items.Count - 1);

            return element;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.items.Count - 1; i >= 0; i--)
            {
                yield return this.items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
