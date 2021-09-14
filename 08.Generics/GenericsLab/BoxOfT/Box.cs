using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BoxOfT
{
    public class Box<T>
    {
        private List<T> data;

        public int Count { get { return data.Count; } }
        public Box()
        {
            data = new List<T>();
        }

        public void Add(T element)
        {
            data.Add(element);
        }

        public T Remove()
        {
            T elementToRemove = data.LastOrDefault();
            data.Remove(elementToRemove);
            return elementToRemove;
        }
    }
}
