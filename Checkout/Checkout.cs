using System;
using System.Collections.Generic;
using System.Linq;

namespace CheckoutKata
{
    public class Checkout
    {
        Dictionary<string, int> _items;

        List<string> scannedItems = new List<string>();

        public Checkout(Dictionary<string, int> items)
        {
            _items = items;
        }

        public void Scan(string item)
        {
            if (_items.ContainsKey(item))
            {
                scannedItems.Add(item);
            }
        }

        public object GetTotalPrice()
        {
            return scannedItems
                .Select(x => _items[x])
                .Sum(x => x);
        }
    }
}
