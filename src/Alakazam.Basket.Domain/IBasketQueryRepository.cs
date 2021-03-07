using System;
using System.Threading.Tasks;

namespace Alakazam.Basket.Domain
{
    public interface IBasketQueryRepository
    {
        Task<Basket> GetByCustomerIdAsync(Guid customerId);
    }
}