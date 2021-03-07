using Alakazam.Framework.Domain;

namespace Alakazam.Basket.Domain.Events
{
    public sealed class BasketItemAddedDomainEvent
        : IDomainEvent
    {
        public Customer Customer { get; private set; }
        public BasketItem.BasketItem Item { get; private set; }
        public BasketItemAddedDomainEvent(Customer customer, BasketItem.BasketItem item)
        {
            Customer = customer;
            Item = item;
        }

    }
}