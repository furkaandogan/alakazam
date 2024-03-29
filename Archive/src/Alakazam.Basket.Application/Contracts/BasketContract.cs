using Alakazam.Framework;
using System;
using System.Collections.Generic;

namespace Alakazam.Basket.Application.Contract
{
    public sealed class BasketContract
    {
        public Guid Id { get; set; }
        public IList<BasketItemContract> Items { get; set; }
        public MoneyContract TotalPrice { get; set; }
        public MoneyContract TotalTax { get; set; }
    }
}