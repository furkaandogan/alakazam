using System;
using Alakazam.Framework;
using Alakazam.Framework.Helpers;

namespace Alakazam.Basket.Domain.BasketItem
{
    public sealed class BasketItem
    {
        public Guid Id { get; set; }
        public ushort Quantity { get; private set; }
        public Product Product { get; private set; }

        public Money Price { get; private set; }
        public Money Tax { get; private set; }

        public BasketItem(ushort quantity, Product product)
            : this(Guid.NewGuid(), quantity, product)
        {

        }

        public BasketItem(Guid id, ushort quantity, Product product)
        {

            Guard.That(id == null || id == Guid.Empty, BasketDomainErrors.BasketItemIdCanNotBeNull);
            Guard.That(quantity <= 0, BasketDomainErrors.BasketItemQuantityCanNotBeEqualOrLessThanZero);
            Guard.That(product == null, BasketDomainErrors.ProductCanNotBeNull);

            Id = id;
            Quantity = quantity;
            Product = product;

            Calculate();
        }

        public BasketItem SetQuantity(ushort quantity)
        {
            Guard.That(Product.Metadata.Stock < quantity, BasketDomainErrors.BasketItemQuantityCanNotBeGreatherThanProductStock);
            Guard.That(Product.Metadata.MaximumPurchasable < quantity, BasketDomainErrors.BasketItemQuantityCanNotBeGreatherThanProductStock);
            Quantity = quantity;
            Calculate();
            
            return this;
        }

        private BasketItem Calculate()
        {
            Price = new Money(0);
            Tax = new Money(0);

            Price = Product.Price * Quantity;
            Tax = Price.CalculateTax(Product.TaxRate);
            return this;
        }

    }
}