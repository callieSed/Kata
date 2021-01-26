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

    }
}
