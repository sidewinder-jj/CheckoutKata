using System;
using System.Collections.Generic;

namespace CheckoutKata
{
    public class Checkout
    {
        Dictionary<string, int> _items;

        List<string> scannedItems = new List<string>();

        public Checkout(Dictionary<string, int> items)
        {
            items = _items;
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
            throw new NotImplementedException();
        }
    }
}
