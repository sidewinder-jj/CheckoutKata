using CheckoutKata;
using System.Collections.Generic;
using Xunit;

namespace CheckoutKataTests
{
    public class CheckoutTests
    {
        Dictionary<string, int> items = new Dictionary<string, int>
        {
            { "A", 50},
            { "B", 30 },
            { "C", 20 },
            { "D", 15 }
        };

        [Fact]
        public void GetTotalPrice_ReturnsUnitPrice_OneItemIsScanned()
        {
            const string sku = "A";

            int unitPrice = items[sku];

            var checkout = new Checkout(items);
        }
    }
}
