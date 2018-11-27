namespace IteratorsAndComparators
{
    using System.Collections;
    using System.Collections.Generic;

    public class Library : IEnumerable<Book>
    {
        private List<Book> books;

        public Library(params Book[] books)
        {
            this.books = new List<Book>(books);
        }

        public IEnumerator<Book> GetEnumerator() => new LibraryIterator(this.books);      

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();


        private class LibraryIterator : IEnumerator<Book>
        {
            private int index;
            private readonly List<Book> books;

            public LibraryIterator(List<Book> books)
            {
                this.Reset();
                this.books = books;
            }

            public Book Current => this.books[index];

            object IEnumerator.Current => this.Current;

            public void Dispose() { }

            public bool MoveNext() => ++this.index < this.books.Count;

            public void Reset() => this.index = -1;
        }
    }
}
