using Kata.Models;
using Xunit;
using System.Linq;

namespace KataTests
{
    public class BasketItemTests
    {
        [Fact]
        public void IfIOneItemIsAddedToBasket_WhenBasketIsEmpty_ThenDiscountIsNotApplied()
        {
            //add the items to the basket
            var userBasket = new Basket();
            MockItemData.GetBasket.ForEach(a => userBasket.Add(a));

            userBasket.Add(MockItemData.GetBasket[0]);
            //assert there is 1 item in the basket with a count of 1
            Assert.Single(userBasket.Where(a => a.Count == 1));
            //assert that the total is only 10
            Assert.Equal(10, userBasket.TotalPrice());
        }

        [Fact]
        public void IfItemsWithMultibuyPromotionsAreAddedToBasket_WhenDiscountRequirementIsMet_ThenDiscountIsApplied()
        {
            var userBasket = new Basket();
            MockItemData.GetBasket.ForEach(a => userBasket.Add(a));

            //add in item B with '3 for 40 discount' in 3 times
            userBasket.Add(MockItemData.GetBasket[1]);
            userBasket.Add(MockItemData.GetBasket[1]);
            userBasket.Add(MockItemData.GetBasket[1]);

            //assert there are 3 items in the basket for item B
            Assert.Equal(3, userBasket[1].Count);
            //assert that the total price is 40 
            Assert.Equal(40, userBasket.TotalPrice());
        }

        [Fact]
        public void IfItemsWithPercentagePromotionsAreAddedToBasket_WhenDiscountRequirementIsMet_ThenDiscountIsApplied()
        {
            var userBasket = new Basket();
            MockItemData.GetBasket.ForEach(a => userBasket.Add(a));

            //add in item item C with '25% off every 2' in twice
            userBasket.Add(MockItemData.GetBasket[3]);
            userBasket.Add(MockItemData.GetBasket[3]);

            //assert there are 2 items in the basket
            Assert.Equal(2, userBasket[3].Count);
            //assert that the total price is (55 x 2 - (25%)) = 82.5
            Assert.Equal(82.5, userBasket.TotalPrice());
        }
    }
}

