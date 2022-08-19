using System.Diagnostics.CodeAnalysis;
using Alakazam.Basket.Application.Contract;

namespace Alakazam.Basket.Application.Usecases.AddProductToBasket
{
    [ExcludeFromCodeCoverage]
    public sealed class AddProductToBasketCommandResult
    {
        public BasketContract Basket { get; set; }
    }
}