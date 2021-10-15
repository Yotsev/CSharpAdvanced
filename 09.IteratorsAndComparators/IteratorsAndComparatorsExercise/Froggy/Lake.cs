using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Froggy
{
    public class Lake : IEnumerable<int>
    {
        private List<int> rocks;

        public Lake(int[] rocks)
        {
            this.rocks = rocks.ToList();
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < rocks.Count; i++)
            {
                if (i%2==0)
                {
                    yield return rocks[i];
                }
            }

            for (int i = rocks.Count-1; i >= 0; i--)
            {
                if (i%2 != 0)
                {
                    yield return rocks[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
