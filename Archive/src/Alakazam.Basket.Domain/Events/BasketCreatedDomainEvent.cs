using System;
using Alakazam.Framework.Domain;

namespace Alakazam.Basket.Domain.Events
{
    public sealed class BasketCreatedDomainEvent
        : IDomainEvent
    {
        public Customer Customer { get; private set; }
        public BasketCreatedDomainEvent(Customer customer)
        {
            Customer = customer;
        }

    }
}