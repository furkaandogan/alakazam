namespace Alakazam.Basket.Domain.BasketItem
{
    public sealed class ProductMetadata
    {
        public string Name { get; private set; }
        public uint Stock { get; private set; }
        public uint MaximumPurchasable { get; private set; }

        public ProductMetadata(string name, uint stock, uint maximumPurchasable)
        {
            Name = name;
            Stock = stock;
            MaximumPurchasable = maximumPurchasable;
        }
    }
}