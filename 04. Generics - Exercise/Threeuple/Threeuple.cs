namespace Threeuple
{
    public class Threeuple<TFirstItem, TSecondItem, TThirdItem>
    {
        private TFirstItem firstItem;
        private TSecondItem seconItem;
        private TThirdItem thirdItem;

        public Threeuple(TFirstItem firstItem, TSecondItem seconItem, TThirdItem thirdItem)
        {
            this.firstItem = firstItem;
            this.seconItem = seconItem;
            this.thirdItem = thirdItem;
        }

        public override string ToString()
        {
            return $"{this.firstItem} -> {this.seconItem} -> {this.thirdItem}";
        }
    }
}
