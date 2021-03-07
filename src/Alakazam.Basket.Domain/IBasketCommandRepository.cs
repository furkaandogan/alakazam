using System;
using System.Threading.Tasks;

namespace Alakazam.Basket.Domain
{
    public interface IBasketCommandRepository
    {
        Task<Basket> UpdateAsync(Basket basket);
    }
}