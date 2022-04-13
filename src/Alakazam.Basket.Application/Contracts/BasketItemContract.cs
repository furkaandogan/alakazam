using System;
using Alakazam.Framework;

namespace Alakazam.Basket.Application.Contract
{
    public sealed class BasketItemContract
    {
        public Guid Id { get; set; }
        public ushort Quantity { get; set; }
        public ProductContract Product { get; set; }
        public MoneyContract Price { get; set; }
        public MoneyContract Tax { get; set; }
    }
}