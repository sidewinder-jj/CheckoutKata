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

            checkout.Scan(sku);

            var result = checkout.GetTotalPrice();

            Assert.Equal(unitPrice, result);
        }

        [Fact]
        public void GetTotalPrice_ReturnsSumOfPrices_MultipleItemsAreScanned()
        {
            const string sku1 = "A";
            const string sku2 = "B";
            const string sku3 = "D";

            int price1 = items[sku1];
            int price2 = items[sku2];
            int price3 = items[sku3];
            int sum = price1 + price2 + price3;

            var checkout = new Checkout(items);

            checkout.Scan(sku1);
            checkout.Scan(sku2);
            checkout.Scan(sku3);

            Assert.Equal(sum, checkout.GetTotalPrice());
        }
    }
}
