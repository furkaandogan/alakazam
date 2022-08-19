using System;
using FluentAssertions;
using Xunit;

namespace Alakazam.Basket.Domain.Test
{
    public class ProductTest
        : BaseTest
    {


        [Fact]
        public void Create_ShouldSuccess_WhenValidProduct()
        {
            Guid productId = Guid.NewGuid();
            BasketItem.Product product = new BasketItem.Product(productId, 10, 18, FakeDataGenerator.CreateProductMetadata());

            product.Id.Should().Be(productId);
            product.Price.Should().NotBeNull();
            product.Price.Amount.Should().Be(10);
            product.TaxRate.Should().Be(18);
        }

        [Fact]
        public void Create_ShouldThrowException_WhenProductPriceEqualsToZero()
        {
            Action basketItemCreate = () =>
            {
                BasketItem.Product product = new BasketItem.Product(Guid.NewGuid(), 0, 0, FakeDataGenerator.CreateProductMetadata());
            };

            basketItemCreate.Should()
                .Throw<DomainException>()
                .And.Message.Should().Be(BasketDomainErrors.ProductPriceCanNotBeLessThanZero.Message);

        }

        [Fact]
        public void Create_ShouldThrowException_WhenProductPriceOrLessToZero()
        {
            Action basketItemCreate = () =>
            {
                BasketItem.Product product = new BasketItem.Product(Guid.NewGuid(), -1, 0, FakeDataGenerator.CreateProductMetadata());
            };

            basketItemCreate.Should()
                .Throw<DomainException>()
                .And.Message.Should().Be(BasketDomainErrors.ProductPriceCanNotBeLessThanZero.Message);

        }
    }
}
