using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alakazam.Basket.Domain;

namespace Alakazam.Basket.Infrastructure
{
    public sealed class BasketInMemoryCommandRepository
        : IBasketCommandRepository
    {

        private readonly InMemoryContext _context;

        public BasketInMemoryCommandRepository(InMemoryContext context)
        {
            _context = context;
        }

        public async Task<Domain.Basket> UpdateAsync(Domain.Basket basket)
        {
            var index = _context.Baskets.IndexOf(basket);
            if(index!=-1)
                _context.Baskets.RemoveAt(index);
            _context.Baskets.Add(basket);
            
            return await Task.FromResult<Domain.Basket>(basket);
        }
    }
}