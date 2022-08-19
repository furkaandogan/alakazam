using System;

namespace Alakazam.Basket.Application.Adapters.Product
{
    public sealed class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal SellingPrice { get; set; }
        public int TaxRate { get; set; }
        public uint Stock { get; set; }
        public uint MaximumPurchasable { get; set; }
    }
}