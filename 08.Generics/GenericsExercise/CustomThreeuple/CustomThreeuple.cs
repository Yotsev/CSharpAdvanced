using System;
using System.Collections.Generic;
using System.Text;

namespace CustomThreeuple
{
   public class CustomThreeuple<T,U,V>
    {
        public T FirstItem { get; set; }
        public U SecondItem { get; set; }
        public V ThirdItem { get; set; }
    }
}
