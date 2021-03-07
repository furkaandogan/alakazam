using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Alakazam.Basket.Infrastructure
{
    [ExcludeFromCodeCoverage]
    public sealed class InMemoryContext
    {
        public IList<Basket.Domain.Basket> Baskets { get; private set; }

        public InMemoryContext()
        {
            Baskets = new List<Basket.Domain.Basket>();
        }

    }
}