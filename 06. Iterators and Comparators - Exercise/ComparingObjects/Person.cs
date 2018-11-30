namespace ComparingObjects
{
    using System;

    public class Person : IComparable<Person>
    {
        private string name;
        private int age;
        private string town;

        public Person(string name, int age, string town)
        {
            this.name = name;
            this.age = age;
            this.town = town;
        }

        public int CompareTo(Person other)
        {
            if (this.name != other.name)
            {
                return this.name.CompareTo(other.name);
            }

            if (this.age != other.age)
            {
                return this.age.CompareTo(other.age);
            }

            return this.town.CompareTo(other.town);
        }
    }
}
