namespace ListyIterator
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ListyIterator<T>
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
    }
}
