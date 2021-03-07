
using System;
using Alakazam.Framework;

namespace Alakazam.Basket.Domain.Commands
{
    public sealed class BasketItemQuantityUpdateCommand
        : ICommand
    {
        public Customer Customer { get; set; }
        public Guid BasketItemId { get; set; }
        public ushort Quantity { get; set; }

        public BasketItemQuantityUpdateCommand(Customer customer, Guid basketItemId, ushort quantity)
        {
            Customer = customer;
            Quantity = quantity;
            BasketItemId = basketItemId;
        }
    }
}