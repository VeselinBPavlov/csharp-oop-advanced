namespace ComparingObjects
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var people = new List<Person>();
            var samePerson = 0;
            var totalPeople = 0;

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                var data = command.Split();
                var name = data[0];
                var age = int.Parse(data[1]);
                var town = data[2];
                var person = new Person(name, age, town);

                people.Add(person);
                totalPeople++;
            }

            var indexPerson = int.Parse(Console.ReadLine());
            var personToCompare = people[indexPerson - 1];

            foreach (var person in people)
            {
                if (person.CompareTo(personToCompare) == 0)
                {
                    samePerson++;
                }
            }

            if (samePerson != 1)
            {
                Console.WriteLine($"{samePerson} {totalPeople - samePerson} {totalPeople}");
            }
            else
            {
                Console.WriteLine("No matches");
            }            
        }
    }
}

