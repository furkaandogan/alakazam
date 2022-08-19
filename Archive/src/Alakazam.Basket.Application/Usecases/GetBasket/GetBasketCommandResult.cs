using System.Diagnostics.CodeAnalysis;
using Alakazam.Basket.Application.Contract;

namespace Alakazam.Basket.Application.Usecases.GetBasket
{
    [ExcludeFromCodeCoverage]
    public sealed class GetBasketCommandResult
    {
        public BasketContract Basket { get; set; }
    }
}