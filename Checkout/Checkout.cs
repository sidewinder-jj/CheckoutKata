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
            return scannedItems
                .Select(x => _items[x])
                .Sum(x => x);
        }
    }
}
