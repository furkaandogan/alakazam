using System;
using Alakazam.Basket.Domain.BasketItem;
using Xunit;

namespace Alakazam.Basket.Domain.Test
{
    public sealed class FakeDataGenerator
    {
        public Product CreateProduct()
            => new Product(Guid.NewGuid(), 10, 18);
    }
}
