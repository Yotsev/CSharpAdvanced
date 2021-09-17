using System;

namespace GenericCountMethodDoubles
{
    public class Box<T> 
        where T : IComparable
    {
        public T Value { get; set; } 

        public override string ToString()
        {
            Type valueType = Value.GetType();
            return $"{valueType.FullName}: {Value}";
        }
    }
}
