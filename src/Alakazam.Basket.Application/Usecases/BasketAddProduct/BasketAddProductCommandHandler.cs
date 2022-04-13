using System.Threading;
using System.Threading.Tasks;
using Alakazam.Basket.Application.Adapters.Product;
using Alakazam.Basket.Application.Contract;
using Alakazam.Basket.Domain;
using Alakazam.Basket.Domain.Commands;
using Alakazam.Framework;
using AutoMapper;

namespace Alakazam.Basket.Application.Usecases.BasketAddProduct
{
    public sealed class BasketAddProductCommandHandler
        : ICommandHandler<BasketAddProductCommand, BasketAddProductCommandResult>
    {
        private readonly IBasketQueryRepository _basketQueryRepository;
        private readonly IBasketCommandRepository _basketCommandRepository;
        private readonly IProductAdapter _productApiAdapter;
        private readonly IMapper _mapper;
        public BasketAddProductCommandHandler(IBasketQueryRepository basketQueryRepository, IBasketCommandRepository basketCommandRepository, IProductAdapter productAdapter, IMapper mapper)
        {
            _basketQueryRepository = basketQueryRepository;
            _basketCommandRepository = basketCommandRepository;
            _productApiAdapter = productAdapter;
            _mapper = mapper;
        }

        public async Task<BasketAddProductCommandResult> HandleAsync(BasketAddProductCommand command, CancellationToken cancellationToken)
        {
            Product productResponse = await _productApiAdapter.GetByIdAsync(command.ProductId, cancellationToken);

            Guard.That(productResponse == null, ApplicationErrors.ProductCanNotBeFetch);

            Basket.Domain.Basket basket = await _basketQueryRepository.GetByCustomerIdAsync(command.Customer.Id);

            if (basket is null)
                basket = new Domain.Basket(command.Customer);

            Domain.BasketItem.Product product = new Domain.BasketItem.Product(productResponse.Id, productResponse.SellingPrice, (sbyte)productResponse.TaxRate)
                .SetMetadata(new Domain.BasketItem.ProductMetadata(productResponse.Name, (uint)productResponse.Stock, (uint)productResponse.MaximumPurchasable));

            basket
                .AddProduct(command.Quantity, product);

            await _basketCommandRepository
                .UpdateAsync(basket);


            return new BasketAddProductCommandResult()
            {
                Basket = _mapper.Map<Basket.Domain.Basket, BasketContract>(basket)
            };

        }
    }

}