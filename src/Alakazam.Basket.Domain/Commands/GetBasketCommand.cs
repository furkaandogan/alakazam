
using System;
using Alakazam.Basket.Domain.BasketItem;
using Alakazam.Framework;

namespace Alakazam.Basket.Domain.Commands
{
    public sealed class GetBasketCommand
        : ICommand
    {
        public Customer Customer { get; set; }
        public GetBasketCommand(Customer customer)
        {
            Customer = customer;
        }
    }
}