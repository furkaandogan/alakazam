using System;

namespace Alakazam.Basket.Infrastructure.Adapters.Product
{
    public sealed class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal SellingPrice { get; set; }
        public int TaxRate { get; set; }
        public int Stock { get; set; }
        public int MaximumPurchasable { get; set; }
    }
}