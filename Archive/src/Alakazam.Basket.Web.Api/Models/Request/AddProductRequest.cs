using System;

namespace Alakazam.Basket.Web.Api.Models.Rquets
{
    public sealed class AddProductRequest
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}