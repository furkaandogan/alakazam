using System;
using System.Threading;
using System.Threading.Tasks;
using Alakazam.Basket.Application.Adapters.Product;
using Alakazam.Basket.Application.Contract;
using Alakazam.Basket.Domain;
using Alakazam.Basket.Domain.Commands;
using Alakazam.Framework;
using AutoMapper;

namespace Alakazam.Basket.Application.Usecases.GetBasket
{
    public sealed class GetBasketCommandHandler
        : ICommandHandler<GetBasketCommand, GetBasketCommandResult>
    {
        private readonly IBasketQueryRepository _basketQueryRepository;
        private readonly IProductAdapter _productAdapter;
        private readonly IMapper _mapper;
        public GetBasketCommandHandler(IBasketQueryRepository basketQueryRepository, IProductAdapter productAdapter, IMapper mapper)
        {
            _basketQueryRepository = basketQueryRepository;
            _productAdapter = productAdapter;
            _mapper = mapper;
        }

        public async Task<GetBasketCommandResult> HandleAsync(GetBasketCommand command, CancellationToken cancellationToken)
        {
            Guard.That(command == null, new ArgumentNullException(nameof(command)));

            Basket.Domain.Basket basket = await _basketQueryRepository.GetByCustomerIdAsync(command.Customer.Id);

            if(basket is null)
                return new GetBasketCommandResult();

            return new GetBasketCommandResult()
            {
                Basket = _mapper.Map<Basket.Domain.Basket, BasketContract>(basket)
            };

        }
    }

}