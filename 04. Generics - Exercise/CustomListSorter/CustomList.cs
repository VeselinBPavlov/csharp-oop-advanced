namespace CustomListSorter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CustomList<T>
        where T:IComparable<T>
    {
        private IList<T> items;

        public CustomList()
        {
            this.items = new List<T>();
        }

        public void Add(T element)
        {
            this.items.Add(element);
        }

        public T Remove(int index)
        {
            var element = this.items[index];
            this.items.RemoveAt(index);
            return element;
        }

        public void Contains(T element)
        {
            if (this.items.Contains(element) == false)
            {
                Console.WriteLine("False");
                return;
            }
            Console.WriteLine("True");
            return;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            var firstItem = this.items[firstIndex];
            var seconItem = this.items[secondIndex];
            this.items[firstIndex] = seconItem;
            this.items[secondIndex] = firstItem;
        }

        public void Greater(T element)
        {
            var counter = 0;
            foreach (var item in this.items)
            {
                var comparator = item.CompareTo(element);

                if (comparator > 0)
                {
                    counter++;
                }
            }

            Console.WriteLine(counter);
        }

        public void Max()
        {
            Console.WriteLine(this.items.Max().ToString()); 
        }

        public void Min()
        {
            Console.WriteLine(this.items.Min().ToString());
        }

        public void Sort()
        {
            this.items = this.items.OrderBy(x => x).ToList();
        }

        public void Print()
        {
            Console.WriteLine(string.Join(Environment.NewLine, this.items));
        }
    }
}
