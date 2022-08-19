using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alakazam.Basket.Domain;

namespace Alakazam.Basket.Infrastructure
{
    public sealed class BasketInMemoryQueryRepository
        : IBasketQueryRepository
    {

        private readonly InMemoryContext _context;

        public BasketInMemoryQueryRepository(InMemoryContext context)
        {
            _context = context;
        }
        public async Task<Domain.Basket> GetByCustomerIdAsync(Guid customerId)
        {
            var basket = _context.Baskets.FirstOrDefault(x => x.Customer.Id == customerId);

            return await Task.FromResult(basket);
        }
    }
}