using System;
using System.Collections.Generic;
using System.Text;

namespace EqualityLogic
{
    public class Person
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

        public override bool Equals(object obj)
        {
            var person = obj as Person;

            return person != null && Name == person.Name && Age == person.Age;
        }
       
        public override int GetHashCode()
        {
            return this.Name.GetHashCode() ^ this.Age.GetHashCode();
        }
    }
}
