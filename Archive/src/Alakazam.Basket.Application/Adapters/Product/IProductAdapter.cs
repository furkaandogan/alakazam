using System;
using System.Threading;
using System.Threading.Tasks;

namespace Alakazam.Basket.Application.Adapters.Product
{
    public interface IProductAdapter
    {
        Task<Product> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}