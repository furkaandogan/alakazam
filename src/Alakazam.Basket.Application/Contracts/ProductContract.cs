using System;
using Alakazam.Framework;

namespace Alakazam.Basket.Application.Contract
{
    public sealed class ProductContract
    {
        public Guid Id { get; set; }
        public Money Price { get; set; }
        public sbyte TaxRate { get; set; }
        public ProductMetadataContract Metadata { get; set; }
    }
}