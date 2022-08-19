using System;
using Alakazam.Framework;

namespace Alakazam.Basket.Domain.BasketItem
{
    public sealed class Product
    {
        public Guid Id { get; private set; }
        public Money Price { get; private set; }
        public sbyte TaxRate { get; private set; }
        public ProductMetadata Metadata { get; private set; }

        public Product(Guid id, Money price, sbyte taxRate,ProductMetadata metadata)
        {
            Guard.That(price <= 0, BasketDomainErrors.ProductPriceCanNotBeLessThanZero);
            Guard.That(taxRate <= 0, BasketDomainErrors.ProductPriceCanNotBeLessThanZero);
            Guard.That(metadata == null, BasketDomainErrors.ProductMetadataCanNotBeNull);

            Id = id;
            Price = price;
            TaxRate = taxRate;
            Metadata = metadata;
        }
    }
}