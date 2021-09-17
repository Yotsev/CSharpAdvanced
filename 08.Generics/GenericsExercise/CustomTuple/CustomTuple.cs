using System;
using System.Collections.Generic;
using System.Text;

namespace CustomTuple
{
    class CustomTuple<T,V>
    {
        public T FirstItem { get; set; }
        public V SecondItem { get; set; }

    }
}
