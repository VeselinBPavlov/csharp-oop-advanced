namespace Tuple
{
    public class Tuple<TFirstItem, TSecondItem>
    {
        private TFirstItem firstItem;
        private TSecondItem seconItem;

        public Tuple(TFirstItem firstItem, TSecondItem seconItem)
        {
            this.firstItem = firstItem;
            this.seconItem = seconItem;
        }

        public override string ToString()
        {
            return $"{this.firstItem} -> {this.seconItem}";
        }
    }
}
