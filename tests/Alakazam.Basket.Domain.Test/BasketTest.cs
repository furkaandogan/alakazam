using System;
using FluentAssertions;
using Xunit;

namespace Alakazam.Basket.Domain.Test
{
    public class BasketTest
        : BaseTest
    {
        [Fact]
        public void Create_ShouldSuccess_WhenValidData()
        {
            Guid productId = Guid.NewGuid();
            BasketItem.Product product = new BasketItem.Product(productId, 10, 18);
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
        public void AddProduct_ShouldSuccess_WhenValidData()
        {
            Guid productId = Guid.NewGuid();
            BasketItem.Product product = new BasketItem.Product(productId, 100, 18)
                .SetMetadata(new BasketItem.ProductMetadata("Test Ürün", 10, 10));
            Basket basket = new Basket(new Customer(Guid.NewGuid()));

            basket.AddProduct(2, product);


            basket.Id.Should().NotBe(Guid.Empty);
            basket.Items.Should().NotBeNull();
            basket.Items.Count.Should().Be(1);
            basket.TotalPrice.Amount.Should().Be(200);
            basket.TotalTax.Amount.Should().Be(36);
        }
        [Fact]
        public void AddProductWithExistsProduct_ShouldSuccess_WhenValidData()
        {
            Guid productId = Guid.NewGuid();
            BasketItem.Product product = new BasketItem.Product(productId, 100, 18)
                .SetMetadata(new BasketItem.ProductMetadata("Test Ürün", 10, 10));
            Basket basket = new Basket(new Customer(Guid.NewGuid()));

            basket.AddProduct(2, product);
            basket.AddProduct(1, product);


            basket.Id.Should().NotBe(Guid.Empty);
            basket.Items.Should().NotBeNull();
            basket.Items.Count.Should().Be(1);
            basket.TotalPrice.Amount.Should().Be(300);
            basket.TotalTax.Amount.Should().Be(54);
        }
        [Fact]
        public void AddProduct_ShouldThrowException_WhenStockLessThanQuantity()
        {
            Guid productId = Guid.NewGuid();
            BasketItem.Product product = new BasketItem.Product(productId, 100, 18)
                .SetMetadata(new BasketItem.ProductMetadata("Test Ürün", 1, 10));
            Basket basket = new Basket(new Customer(Guid.NewGuid()));
            Action addProduct = () =>
                       {
                           basket.AddProduct(2, product);
                       };

            addProduct.Should().Throw<DomainException>().And
            .Message.Should().Be(BasketDomainErrors.BasketItemQuantityCanNotBeGreatherThanProductStock.Message);
        }
        [Fact]
        public void AddProduct_ShouldThrowException_WhenMaximumPurchasableLessThanQuantity()
        {
            Guid productId = Guid.NewGuid();
            BasketItem.Product product = new BasketItem.Product(productId, 100, 18)
                .SetMetadata(new BasketItem.ProductMetadata("Test Ürün", 10, 1));
            Basket basket = new Basket(new Customer(Guid.NewGuid()));
            Action addProduct = () =>
                       {
                           basket.AddProduct(2, product);
                       };

            addProduct.Should().Throw<DomainException>().And
            .Message.Should().Be(BasketDomainErrors.BasketItemQuantityCanNotBeGreatherThanProductMaximumPurchasable.Message);
        }
    }
}
