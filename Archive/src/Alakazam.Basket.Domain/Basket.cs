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
        public Money Discount { get; private set; }

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
            Guard.That(quantity <= 0, BasketDomainErrors.BasketItemQuantityCanNotBeEqualOrLessThanZero);

            Guard.That(product.Metadata.MaximumPurchasable < quantity, BasketDomainErrors.BasketItemQuantityCanNotBeGreatherThanProductMaximumPurchasable);

            // Guard.That(Items.Any(x=>x.Product.Id==product.Id), BasketDomainErrors.ProductCanNotBeExists);

            BasketItem.BasketItem findedBasketItem = Items.FirstOrDefault(x => x.Product.Id == product.Id);

            if (findedBasketItem == null)
            {
                findedBasketItem = new BasketItem.BasketItem(quantity, product);
                Items.Add(findedBasketItem);
            }
            else
            {
                findedBasketItem.IncQuantity();
            }


            Calculate();

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