namespace Database
{
    using System;
    using System.Linq;

    public class Database
    {
        private const int Capacity = 16;
        private int[] data;
        private int index;

        public Database()
        {
            this.data = new int[Capacity];
            this.index = -1;
        }

        public Database(int[] array)
            :this()
        {
            FillDatabase(array);
        }

        public void Add(int number)
        {
            if (this.index == Capacity - 1)
            {
                throw new InvalidOperationException("There is no empty space in database!");
            }

            index++;
            this.data[this.index] = number;

        }

        public void Remove()
        {
            if (this.index == -1)
            {
                throw new InvalidOperationException("Cannot remove element from empty database!");
            }

            this.data[this.index] = 0;
            this.index--;
        }

        public int[] Fetch()
        {
            return this.data.Take(this.index + 1).ToArray();
        }

        private void FillDatabase(int[] array)
        {
            if (array.Length > Capacity)
            {
                throw new InvalidOperationException("Input array length is bigger than database length!");
            }

            for (int i = 0; i < array.Length; i++)
            {
                this.data[i] = array[i];                
            }

            this.index = array.Length - 1;
        }
    }
}
