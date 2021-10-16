using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace EqualityLogic
{
    public class Person : IComparable<Person>
    {
        private string name;
        private int age;


        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public string Name { get { return this.name; } }
        public int Age { get { return this.age; } }

        public int CompareTo(Person other)
        {
            int result = Name.CompareTo(other.Name);

            if (result == 0)
            {
                result = Age.CompareTo(other.Age);
            }

            return result;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() ^ Age.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var other = obj as Person;

            if (other == null)
            {
                return false;
            }

            return this.Name == other.Name && this.Age == other.Age;
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Age}";
        }
    }
}
