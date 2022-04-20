using System;
using System.Threading;
using System.Threading.Tasks;
using Alakazam.Basket.Application.Adapters.Product;
using Alakazam.Basket.Application.Contract;
using Alakazam.Basket.Domain;
using Alakazam.Basket.Domain.Commands;
using Alakazam.Framework;
using AutoMapper;

namespace Alakazam.Basket.Application.Usecases.AddProductToBasket
{
    public sealed class AddProductToBasketCommandHandler
        : ICommandHandler<BasketAddProductCommand, AddProductToBasketCommandResult>
    {
        private readonly IBasketQueryRepository _basketQueryRepository;
        private readonly IBasketCommandRepository _basketCommandRepository;
        private readonly IProductAdapter _productAdapter;
        private readonly IMapper _mapper;
        public AddProductToBasketCommandHandler(IBasketQueryRepository basketQueryRepository, IBasketCommandRepository basketCommandRepository, IProductAdapter productAdapter, IMapper mapper)
        {
            _basketQueryRepository = basketQueryRepository;
            _basketCommandRepository = basketCommandRepository;
            _productAdapter = productAdapter;
            _mapper = mapper;
        }

        public async Task<AddProductToBasketCommandResult> HandleAsync(BasketAddProductCommand command, CancellationToken cancellationToken)
        {
            Guard.That(command == null, new ArgumentNullException(nameof(command)));

            Basket.Domain.Basket basket = await _basketQueryRepository.GetByCustomerIdAsync(command.Customer.Id);

            if (basket is null)
                basket = new Domain.Basket(command.Customer);

            Product product = await _productAdapter.GetByIdAsync(command.ProductId, cancellationToken);

            Domain.BasketItem.Product basketProduct = new Domain.BasketItem.Product(product.Id, product.SellingPrice, (sbyte)product.TaxRate, new Domain.BasketItem.ProductMetadata(product.Name, product.Stock, product.MaximumPurchasable));

            basket.AddProduct(command.Quantity, basketProduct);

            await _basketCommandRepository.UpdateAsync(basket);

            return new AddProductToBasketCommandResult()
            {
                Basket = _mapper.Map<Basket.Domain.Basket, BasketContract>(basket)
            };

        }
    }

}