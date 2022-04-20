using System;
using FluentAssertions;
using Xunit;

namespace Alakazam.Basket.Domain.Test
{
    public class BasketItemTest
        : BaseTest
    {
        [Fact]
        public void Create_ShouldSuccess_WhenValidData()
        {
            Guid productId = Guid.NewGuid();
            BasketItem.Product product = new BasketItem.Product(productId, 10, 18,FakeDataGenerator.CreateProductMetadata());
            BasketItem.BasketItem basketItem = new BasketItem.BasketItem(2, product);

            basketItem.Id.Should().NotBe(Guid.Empty);
            basketItem.Quantity.Should().Be(2);
            basketItem.Product.Should().NotBeNull();
            basketItem.Product.Id.Should().Be(productId);
            basketItem.Product.Price.Should().NotBeNull();
            basketItem.Product.Price.Amount.Should().Be(10);
            basketItem.Product.TaxRate.Should().Be(18);
        }
        [Fact]
        public void Create_ShouldThrowException_WhenIdEqualsToEmpty()
        {
            Action basketItemCreate = () =>
            {
                BasketItem.BasketItem basketItem = new BasketItem.BasketItem(Guid.Empty, 1, FakeDataGenerator.CreateProduct());
            };

            basketItemCreate.Should()
                .Throw<DomainException>()
                .And.Message.Should().Be(BasketDomainErrors.BasketItemIdCanNotBeNull.Message);
        }

        [Fact]
        public void Create_ShouldThrowException_WhenQuantityEqualsToZero()
        {
            Action basketItemCreate = () =>
            {
                BasketItem.BasketItem basketItem = new BasketItem.BasketItem(Guid.NewGuid(), 0, FakeDataGenerator.CreateProduct());
            };

            basketItemCreate.Should()
                .Throw<DomainException>()
                .And.Message.Should().Be(BasketDomainErrors.BasketItemQuantityCanNotBeEqualOrLessThanZero.Message);
        }

        [Fact]
        public void Create_ShouldThrowException_WhenProductEqualsToNull()
        {
            Action basketItemCreate = () =>
            {
                BasketItem.BasketItem basketItem = new BasketItem.BasketItem(Guid.NewGuid(), 1, null);
            };

            basketItemCreate.Should()
                .Throw<DomainException>()
                .And.Message.Should().Be(BasketDomainErrors.ProductCanNotBeNull.Message);
        }

        [Fact]
        public void Create_ShouldThrowException_WhenProductPriceEqualsToZero()
        {
            Action basketItemCreate = () =>
            {
                BasketItem.BasketItem basketItem = new BasketItem.BasketItem(Guid.NewGuid(), 1, new BasketItem.Product(Guid.NewGuid(), 0, 0, FakeDataGenerator.CreateProductMetadata()));
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
                BasketItem.BasketItem basketItem = new BasketItem.BasketItem(Guid.NewGuid(), 1, new BasketItem.Product(Guid.NewGuid(), -1, 0, FakeDataGenerator.CreateProductMetadata()));
            };

            basketItemCreate.Should()
                .Throw<DomainException>()
                .And.Message.Should().Be(BasketDomainErrors.ProductPriceCanNotBeLessThanZero.Message);

        }
    }
}
