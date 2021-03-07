using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Alakazam.Basket.Infrastructure.Adapters.Product
{
    public sealed class ProductApiAdapter
    {
        private readonly IList<Product> _products;

        public ProductApiAdapter()
        {
            _products = new List<Product>(){
                new Product(){
                    Id = Guid.Parse("c43e8047-7e39-4ed5-8465-8d41a556dd24"),
                    MaximumPurchasable=1,
                    Name="Mevye Sepeti",
                    SellingPrice = 50,
                    TaxRate = 18,
                    Stock=10
                },new Product(){
                    Id = Guid.Parse("d3d44267-d4ea-4df4-9857-eac75d59983b"),
                    MaximumPurchasable=10,
                    Name="Mevye Tabağı",
                    SellingPrice = 50,
                    TaxRate = 18,
                    Stock=10
                },new Product(){
                    Id = Guid.Parse("d3d44267-d4ea-4df4-9857-eac75d59983a"),
                    MaximumPurchasable=10,
                    Name="Papatya",
                    SellingPrice = 10,
                    TaxRate = 18,
                    Stock=0
                }
            };
        }
        public async Task<Product> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            // todo: http client ile ilgili servisten data çekilecek.
            return await Task.FromResult(_products.FirstOrDefault(x => x.Id == id));
        }
    }
}