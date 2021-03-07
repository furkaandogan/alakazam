using System.Diagnostics.CodeAnalysis;
using Alakazam.Basket.Application.Contract;

namespace Alakazam.Basket.Application.Usecases.BasketAddProduct
{
    [ExcludeFromCodeCoverage]
    public sealed class BasketAddProductCommandResult
    {
        public BasketContract Basket { get; set; }
    }
}