using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Alakazam.Basket.Application.Contract;
using Alakazam.Basket.Application.Usecases;
using Alakazam.Basket.Application.Usecases.BasketAddProduct;
using Alakazam.Basket.Application.Usecases.GetBasket;
using Alakazam.Basket.Domain.Commands;
using Alakazam.Basket.Web.Api.Models.Request.AddProduct;
using Alakazam.Framework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Alakazam.Basket.Web.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BasketController : ControllerBase
    {
        private readonly ILogger<BasketController> _logger;
        private readonly IdentityContext _identityContext;

        public BasketController(ILogger<BasketController> logger, IdentityContext identityContext)
        {
            _logger = logger;
            _identityContext = identityContext;
        }

        [HttpGet]
        public async Task<BasketContract> GetAsync([FromServices] ICommandHandler<GetBasketCommand, GetBasketCommandResult> handler)
        {
            GetBasketCommandResult result = await handler.HandleAsync(new GetBasketCommand(_identityContext.Get().ToCustomer()), new CancellationToken());
            return result.Basket;
        }

        [HttpPost]
        public async Task<BasketContract> AddProductAsync([FromServices] ICommandHandler<BasketAddProductCommand, BasketAddProductCommandResult> handler, [FromBody] AddProductRequest request)
        {
            BasketAddProductCommandResult result = await handler.HandleAsync(new BasketAddProductCommand(_identityContext.Get().ToCustomer(), request.Quantity, request.ProductId), new CancellationToken());
            return result.Basket;
        }
    }
}
