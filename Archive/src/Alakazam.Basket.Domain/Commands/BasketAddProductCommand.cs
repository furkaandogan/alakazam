
using System;
using Alakazam.Basket.Domain.BasketItem;
using Alakazam.Framework;

namespace Alakazam.Basket.Domain.Commands
{
    public sealed class BasketAddProductCommand
        : ICommand
    {
        public Customer Customer { get; set; }
        public Guid ProductId { get; set; }
        public ushort Quantity { get; set; }

        public BasketAddProductCommand(Customer customer, ushort quantity, Guid productId)
        {
            Customer = customer;
            Quantity = quantity;
            ProductId = productId;
        }
    }
}