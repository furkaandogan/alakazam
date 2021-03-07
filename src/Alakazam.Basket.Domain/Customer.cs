using System;
using System.Diagnostics.CodeAnalysis;

namespace Alakazam.Basket.Domain
{
    [ExcludeFromCodeCoverage]
    public sealed class Customer
    {
        public Guid Id { get; private set; }


        public Customer(Guid id)
        {
            Id = id;
        }
    }
}