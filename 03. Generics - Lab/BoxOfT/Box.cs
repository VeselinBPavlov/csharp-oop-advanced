using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BoxOfT
{
    public class Box<T>
    {
        private IList<T> collection;

        public int Count => this.collection.Count;

        public Box()
        {
            collection = new List<T>();
        }        

        public void Add(T element)
        {
            collection.Add(element);
        }

        public T Remove()
        {
            var last = collection[collection.Count - 1];
            collection.RemoveAt(collection.Count - 1);
            return last;
        }
    }
}
