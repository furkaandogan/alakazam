using System.Diagnostics.CodeAnalysis;
using System.Net;

namespace Alakazam.Basket.Domain
{
    [ExcludeFromCodeCoverage]
    public class BasketDomainErrors
    {
        public static DomainException BasketItemIdCanNotBeNull;
        public static DomainException BasketItemQuantityCanNotBeEqualOrLessThanZero;
        public static DomainException ProductCanNotBeNull;
        public static DomainException ProductPriceCanNotBeLessThanZero;
        public static DomainException ProductTaxRateCanNotBeLessThanZero;
        public static DomainException FindedBasketItemCanNotBeNull;
        public static DomainException ProductMetadataCanNotBeNull;
        public static DomainException BasketItemQuantityCanNotBeGreatherThanProductStock;
        public static DomainException BasketItemQuantityCanNotBeGreatherThanProductMaximumPurchasable;

        static BasketDomainErrors()
        {
            BasketItemIdCanNotBeNull = new DomainException("BasketItemIdCanNotBeNull", "<doc-link>", HttpStatusCode.BadRequest);
            BasketItemQuantityCanNotBeEqualOrLessThanZero = new DomainException("BasketItemQuantityCanNotBeEqualOrLessThanZero", "<doc-link>", HttpStatusCode.BadRequest);
            ProductCanNotBeNull = new DomainException("ProductCanNotBeNull", "<doc-link>", HttpStatusCode.BadRequest);
            ProductPriceCanNotBeLessThanZero = new DomainException("ProductPriceCanNotBeLessThanZero", "<doc-link>");
            ProductTaxRateCanNotBeLessThanZero = new DomainException("ProductTaxRateCanNotBeLessThanZero", "<doc-link>");
            FindedBasketItemCanNotBeNull = new DomainException("FindedBasketItemCanNotBeNull", "<doc-link>", HttpStatusCode.BadRequest);
            ProductMetadataCanNotBeNull = new DomainException("ProductMetadataCanNotBeNull", "<doc-link>");
            BasketItemQuantityCanNotBeGreatherThanProductStock = new DomainException("BasketItemQuantityCanNotBeGreatherThanProductStock", "<doc-link>", HttpStatusCode.PreconditionFailed);
            BasketItemQuantityCanNotBeGreatherThanProductMaximumPurchasable = new DomainException("BasketItemQuantityCanNotBeGreatherThanProductMaximumPurchasable", "<doc-link>", HttpStatusCode.PreconditionFailed);

        }
    }
}