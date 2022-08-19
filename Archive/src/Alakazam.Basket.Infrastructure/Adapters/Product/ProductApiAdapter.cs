using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Alakazam.Basket.Application.Adapters.Product;

namespace Alakazam.Basket.Infrastructure.Adapters.Product
{
    public sealed class ProductApiAdapter
        : IProductAdapter
    {
        private readonly IList<Application.Adapters.Product.Product> _products;

        public ProductApiAdapter()
        {
            _products = new List<Application.Adapters.Product.Product>(){
                new Application.Adapters.Product.Product(){
                    Id = Guid.Parse("c43e8047-7e39-4ed5-8465-8d41a556dd24"),
                    MaximumPurchasable=1,
                    Name="Mevye Sepeti",
                    SellingPrice = 50,
                    TaxRate = 18,
                    Stock=10
                },new Application.Adapters.Product.Product(){
                    Id = Guid.Parse("d3d44267-d4ea-4df4-9857-eac75d59983b"),
                    MaximumPurchasable=10,
                    Name="Mevye Tabağı",
                    SellingPrice = 50,
                    TaxRate = 18,
                    Stock=10
                },new Application.Adapters.Product.Product(){
                    Id = Guid.Parse("d3d44267-d4ea-4df4-9857-eac75d59983a"),
                    MaximumPurchasable=10,
                    Name="Papatya",
                    SellingPrice = 10,
                    TaxRate = 18,
                    Stock=0
                }
            };
        }
        public async Task<Application.Adapters.Product.Product> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            // todo: http client ile ilgili servisten data çekilecek.
            return await Task.FromResult(_products.FirstOrDefault(x => x.Id == id));
        }
    }
}