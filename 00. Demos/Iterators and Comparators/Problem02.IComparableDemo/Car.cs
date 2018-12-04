using System;

namespace Problem02.IComparableDemo
{
    public class Car : IComparable<Car>
    {
        public int Year { get; set; }

        public int CompareTo(Car other)
        {
            return this.Year.CompareTo(other.Year);
        }
    }
}
