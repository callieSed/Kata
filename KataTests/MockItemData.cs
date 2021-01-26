using Kata.Models;

namespace KataTests
{
    public static class MockItemData
    {
        public static Basket GetBasket => new Basket()
                {
                    new BasketItem()
                    {
                        ItemName = "A",
                        Price = 10,
                    },
                    new BasketItem()
                    {
                        ItemName = "B",
                        Price = 15,
                        DiscountTotal = 40,
                        DiscountMuliBuy = 3
                    },
                    new BasketItem()
                    {
                        ItemName = "C",
                        Price = 40
                    },
                    new BasketItem()
                    {
                        ItemName = "D",
                        Price = 55,
                        DiscountPercent = 0.25,
                        DiscountMuliBuy = 2
                    }
                };
    }
}

