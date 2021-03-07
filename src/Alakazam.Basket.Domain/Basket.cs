using System;
using System.Collections.Generic;
using System.Linq;
using Alakazam.Basket.Domain.BasketItem;
using Alakazam.Basket.Domain.Events;
using Alakazam.Framework;
using Alakazam.Framework.Domain;

namespace Alakazam.Basket.Domain
{
    public sealed class Basket
        : BaseAggregate
    {
        public Customer Customer { get; set; }
        public ICollection<BasketItem.BasketItem> Items { get; private set; }
        public Money TotalPrice { get; private set; }
        public Money TotalTax { get; private set; }


        public Basket(Customer customer)
            : base()
        {
            Customer = customer;
            Items = new List<BasketItem.BasketItem>();

            AddEvent(new BasketCreatedDomainEvent(customer));
        }


        public Basket AddProduct(ushort quantity, Product product)
        {
            Guard.That(product == null, BasketDomainErrors.ProductCanNotBeNull);
            Guard.That(product.Metadata == null, BasketDomainErrors.ProductMetadataCanNotBeNull);

            Guard.That(product.Metadata.Stock < quantity, BasketDomainErrors.BasketItemQuantityCanNotBeGreatherThanProductStock);
            Guard.That(product.Metadata.MaximumPurchasable < quantity, BasketDomainErrors.BasketItemQuantityCanNotBeGreatherThanProductMaximumPurchasable);

            BasketItem.BasketItem basketItem = Items.FirstOrDefault(x => x.Product.Id == product.Id);
            if (basketItem == null)
            {
                basketItem = new BasketItem.BasketItem(quantity, product);
                Items.Add(basketItem);
            }
            else
                basketItem.SetQuantity((ushort)(basketItem.Quantity + quantity));

            Calculate();

            AddEvent(new BasketItemAddedDomainEvent(Customer, basketItem));
            return this;
        }

        public Basket BasketItemQuantityUpdate(Guid basketItemId, ushort quantity)
        {
            Guard.That(basketItemId == null || basketItemId == Guid.Empty, BasketDomainErrors.BasketItemIdCanNotBeNull);

            Guard.That(quantity <= 0, BasketDomainErrors.BasketItemQuantityCanNotBeEqualOrLessThanZero);

            BasketItem.BasketItem findedBasketItem = Items.FirstOrDefault(x => x.Id == basketItemId);

            Guard.That(findedBasketItem == null, BasketDomainErrors.FindedBasketItemCanNotBeNull);

            findedBasketItem.SetQuantity(quantity);

            Calculate();

            AddEvent(new BasketItemQuantityUpdatedDomainEvent(Customer, findedBasketItem));

            return this;
        }

        private Basket Calculate()
        {
            TotalPrice = new Money(0);
            TotalTax = new Money(0);
            foreach (BasketItem.BasketItem basketItem in Items)
            {
                TotalPrice += basketItem.Price;
                TotalTax += basketItem.Tax;
            }
            return this;
        }
    }
}