using System.Linq;
using System.Collections.Generic;

namespace Kata.Models
{
    public class Basket: List<BasketItem>
    {
        public new void Add(BasketItem item)
        {
            var existingItem = this.Any(a => a.ItemName == item.ItemName);
            if (existingItem)
            {
                this.First(a => a.ItemName == item.ItemName).Count++;
            }
            else
            {
                Add(item);
            }
        }

        public new void Remove(BasketItem item)
        {
            var existingItem = this.First(a => a.ItemName == item.ItemName);
            if (item.Count > 0)
                item.Count--;
        }

        public double TotalPrice()
        {
            double totalSum = 0;
            foreach (var item in this.Where(a => a.Count > 0))
            {
                totalSum += item.GetTotalPrice();
            }

            return totalSum;
        }
    }
}


