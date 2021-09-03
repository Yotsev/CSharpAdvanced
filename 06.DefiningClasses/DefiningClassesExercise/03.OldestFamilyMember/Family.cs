using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> people;

        public Family()
        {
            People = new List<Person>();
        }

        public List<Person> People
        {
            get { return people; }
            set { people = value; }
        }

        public void AddMember(Person member)
        {
            People.Add(member);
        }

        public Person GetOldestMember()
        {
            Person oldest = new Person();

            foreach (Person person in people)
            {
                if (person.Age > oldest.Age)
                {
                    oldest = person;
                }
            }

            return oldest;
        }

    }
}
