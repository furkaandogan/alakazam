using System;

namespace Alakazam.Basket.Web.Api.Models.Request.AddProduct
{
    public sealed class AddProductRequest
    {
        public ushort Quantity { get; set; }
        public Guid ProductId { get; set; }
    }
}