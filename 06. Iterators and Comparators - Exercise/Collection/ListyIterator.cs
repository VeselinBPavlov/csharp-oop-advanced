namespace Collection
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ListyIterator<T> : IEnumerable<T>
    {
        private IList<T> items;
        private int index;

        public ListyIterator()
        {
            this.items = new List<T>();
            this.index = 0;
        }

        public void Create(T[] items)
        {
            foreach (var item in items)
            {
                this.items.Add(item);
            }
        }

        public bool Move()
        {
            if (this.index == this.items.Count - 1)
            {
                return false;
            }
            this.index++;
            return true;
        }

        public void Print()
        {
            if (this.items.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            Console.WriteLine(this.items[this.index]);
        }

        public bool HasNext()
        {
            if (this.index == this.items.Count - 1)
            {
                return false;
            }
            return true;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < items.Count; i++)
            {
                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        public void PrintAll()
        {
            Console.WriteLine(string.Join(" ", this.items));
        }
    }
}
