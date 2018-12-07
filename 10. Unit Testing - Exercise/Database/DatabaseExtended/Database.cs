namespace DatabaseExtended
{
    using System;
    using System.Linq;

    public class Database
    {
        private const int Capacity = 16;
        private Person[] people;
        private int index;

        public Database()
        {
            this.people = new Person[Capacity];
            this.index = -1;
        }

        public void Add(Person otherPerson)
        {
            var isUsernameExists = this.people.Any(p => p != null && p.Name == otherPerson.Name);

            if (isUsernameExists)
            {
                throw new InvalidOperationException("There is already a person with the same name!");
            }

            var isIdExists = this.people.Any(p => p != null && p.Id == otherPerson.Id);

            if (isIdExists)
            {
                throw new InvalidOperationException("There is already a person with the same Id!");
            }

            index++;
            this.people[this.index] = otherPerson;
        }

        public void Remove()
        {
            if (this.index == -1)
            {
                throw new InvalidOperationException("Cannot remove element from empty database!");
            }

            this.people[this.index] = null;
            this.index--;
        }

        public Person FindByUsername(string username)
        {
            if (username == null)
            {
                throw new ArgumentNullException("Username cannot be null.");
            }

            var isPersonExists = this.people.Any(p => p != null && p.Name == username);

            if (isPersonExists == false)
            {
                throw new InvalidOperationException("Person does not exists in database.");
            }

            return people.FirstOrDefault(x => x.Name == username);
        }

        public Person FindById(long id)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException("Id cannot be negative.");
            }

            var isPersonExists = this.people.Any(p => p != null && p.Id == id);

            if (isPersonExists == false)
            {
                throw new InvalidOperationException("No person found with that username!");
            }

            return people.FirstOrDefault(x => x.Id == id);
        }
    }
}
