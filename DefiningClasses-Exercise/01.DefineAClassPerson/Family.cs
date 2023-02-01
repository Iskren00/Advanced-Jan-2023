using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> people;

        public Family()
        {
            this.people = new List<Person>();
        }

        public List<Person> People { get { return people; } }

        public void AddMember(Person member) 
        { 
            people.Add(member);
        }

        public Person GetOldestMember()
        {
            return this.people.MaxBy(p => p.Age);
        }

        public List<Person> GetAllOver30(List<Person> persons)
        {
            List<Person> result = new (persons);

            foreach (var person in persons)
            {
                if (person.Age <= 30)
                {
                    result.Remove(person);
                }
            }

            return result;
        }
    }
}
