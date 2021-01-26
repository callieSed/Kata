namespace Kata.Models
{
    public class BasketItem
    {
        public string ItemName { get; set; }
        public double Price { get; set; }
        public int Count { get; set; } = 0;
        public double DiscountPercent { get; set; } = 0;
        public int DiscountMuliBuy { get; set; } = 0;
        public int DiscountTotal { get; set; } = 0;

        public double GetTotalPrice()
        {
            if (DiscountMuliBuy >= Count)
            {
                return CalculateDiscount();
            }
            return Price * Count;
        }

        private double CalculateDiscount()
        {
            var timesToBeApplied = Count / DiscountMuliBuy;
            var remainder = Count % DiscountMuliBuy;
            if (DiscountPercent > 0)
            {
                double subTotal = Price * Count;
                double amountToDiscount = subTotal * DiscountPercent;
                double totalPriceAfterDiscount = subTotal - (amountToDiscount * timesToBeApplied);
                return totalPriceAfterDiscount += (remainder * Price);
            }
            else if (DiscountTotal > 0)
            {
                var totalDiscountSum = timesToBeApplied * DiscountTotal;
                return totalDiscountSum + (remainder * Price);
            }
            return 0;
        }
    }
}
