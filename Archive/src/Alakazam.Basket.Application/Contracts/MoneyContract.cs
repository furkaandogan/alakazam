using System;
using Alakazam.Framework;

namespace Alakazam.Basket.Application.Contract
{
    public sealed class MoneyContract
    {
        public decimal Amount { get; private set; }
        public Currency Currency { get; private set; }
        public sbyte Round { get; private set; }
    }
}