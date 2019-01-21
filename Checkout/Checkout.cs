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
                var totalPrice = 0;

                var itemsByQuantity = scannedItems
                .GroupBy(x => x)
                .Select(g => new { Sku = g.Key, Count = g.Count() });

                foreach (var item in itemsByQuantity)
                {
                    var quantity = item.Count;
                    var unitPrice = _items[item.Sku];

                    var discount = (_discounts
                        .Where(x => x.Sku == item.Sku)
                        .SingleOrDefault());

                    var discountPrice = discount.DiscountPrice;
                    var quantityRequired = discount.QuantityRequired;

                    totalPrice += (quantity / quantityRequired * discountPrice);
                    totalPrice += (quantity % quantityRequired * unitPrice);
                }

                return totalPrice;
            }

            return scannedItems
                .Select(x => _items[x])
                .Sum(x => x);
        }
    }
}
