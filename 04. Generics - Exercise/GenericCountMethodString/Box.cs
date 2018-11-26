namespace GenericCountMethodString
{
    using System;
    using System.Collections.Generic;

    public class Box<T>
        where T:IComparable<T>
    {
        public IList<T> Items { get; set; }

        public Box()
        {
            this.Items = new List<T>();
        }

        public int CountGreaterElements(T element)
        {
            var counter = 0;
            foreach (var item in this.Items)
            {                
                var comparator = item.CompareTo(element);

                if (comparator > 0)
                {
                    counter++;
                }                
            }

            return counter;
        }
    }
}
