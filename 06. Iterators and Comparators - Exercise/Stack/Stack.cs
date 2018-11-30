namespace Stack
{
    using System.Collections;
    using System.Collections.Generic;

    public class Stack<T> : IEnumerable<T>
    {
        private T[] items;
        private int count;

        public int Count { get; private set; }

        public Stack()
        {
            this.count = 4;
            this.items = new T[count];
        }

        public void Push(T element)
        {
            if (this.Count == this.items.Length)
            {
                var cloningArr = new T[this.count *= 2];
                this.items.CopyTo(cloningArr, 0);
                this.items = cloningArr;
            }

            this.items[this.Count] = element;
            this.Count++;
        }

        public T Pop()
        {
            this.Count--;
            var element = this.items[this.Count];
            this.items[this.Count] = default(T);

            return element;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                yield return this.items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();        
    }
}
