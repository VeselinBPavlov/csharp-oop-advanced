namespace StrategyPattern
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var list = new List<Person>();
            for (int i = 0; i < n; i++)
            {
                var data = Console.ReadLine().Split();
                list.Add(new Person(data[0], int.Parse(data[1])));
            }

            PrintSet(list, new NameComparer());
            PrintSet(list, new AgeComparer());
        }

        static void PrintSet<T>(List<Person> people, T comparer)
            where T : IComparer<Person>
        {
            SortedSet<Person> set = new SortedSet<Person>(people, comparer);

            foreach (var person in set)
            {
                Console.WriteLine(person);
            }
        }
    }    
}
