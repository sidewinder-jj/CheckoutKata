using System.Collections.Generic;
using System.Linq;

namespace CheckoutKata
{
    public class Checkout : ICheckout
    {
        private readonly Dictionary<string, int> _items;
        private readonly List<Discount> _discounts;

        private List<string> scannedItems = new List<string>();

        public Checkout(Dictionary<string, int> items)
        {
            _items = items;
        }

        public Checkout(Dictionary<string, int> items, List<Discount> discounts)
        {
            _items = items;
            _discounts = discounts;
        }

        public void Scan(string item)
        {
            if (_items.ContainsKey(item))
            {
                scannedItems.Add(item);
            }
        }

        public int GetTotalPrice()
        {
            if (_discounts != null)
            {
                var totalPrice = ApplyDiscounts(scannedItems, _discounts);

                return totalPrice;
            }

            return scannedItems
                .Select(x => _items[x])
                .Sum(x => x);
        }

        private int ApplyDiscounts(List<string> items, List<Discount> discounts)
        {
            var itemsByQuantity = items
                .GroupBy(x => x)
                .Select(g => new ItemByQuantity { Sku = g.Key, Count = g.Count() });

            var price = CalculateDiscounts(itemsByQuantity, discounts);

            return price;
        }

        private int CalculateDiscounts(IEnumerable<ItemByQuantity> itemsByQuantity, List<Discount> discounts)
        {
            var price = 0;

            foreach (var item in itemsByQuantity)
            {
                var quantity = item.Count;
                var unitPrice = _items[item.Sku];

                var discount = (discounts
                    .Where(x => x.Sku == item.Sku)
                    .SingleOrDefault());

                    var discountPrice = discount.DiscountPrice;
                    var quantityRequired = discount.QuantityRequired;

                    price += (quantity / quantityRequired * discountPrice);
                    price += (quantity % quantityRequired * unitPrice);
            }

            return price;
        }
    }
}
