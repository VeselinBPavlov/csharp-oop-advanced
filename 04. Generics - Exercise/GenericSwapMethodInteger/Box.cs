namespace GenericSwapMethodInteger
{
    using System.Collections.Generic;
    using System.Text;

    public class Box<T>
    {
        public IList<T> Items { get; set; }

        public Box()
        {
            this.Items = new List<T>();
        }

        public void SwapItems(int firstIndex, int secondIndex)
        {
            var firstItem = this.Items[firstIndex];
            var seconItem = this.Items[secondIndex];
            this.Items[firstIndex] = seconItem;
            this.Items[secondIndex] = firstItem;
        }


        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var item in this.Items)
            {
                sb.AppendLine($"System.{item.GetType().Name}: {item}");
            }

            return sb.ToString().TrimEnd();            
        }
    }
}
