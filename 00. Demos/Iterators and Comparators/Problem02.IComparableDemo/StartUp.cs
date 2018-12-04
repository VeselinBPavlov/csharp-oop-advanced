using System;
using System.Collections.Generic;

namespace Problem02.IComparableDemo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var sortedCars = new SortedSet<Car>();

            sortedCars.Add(new Car() {Year = 2005});
            sortedCars.Add(new Car() {Year = 2008});
            sortedCars.Add(new Car() {Year = 2010});

            foreach (var item in sortedCars)
            {
                Console.WriteLine(item.Year);
            }
        }
    }
}
