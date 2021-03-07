using Alakazam.Basket.Application.Contract;
using AutoMapper;

namespace Alakazam.Basket.Application.Mappings
{
    public sealed class BasketContractProfile
        : Profile
    {
        public BasketContractProfile()
        {
            CreateMap<Basket.Domain.Basket,BasketContract>();
            CreateMap<Basket.Domain.BasketItem.BasketItem, BasketItemContract>();
            CreateMap<Basket.Domain.BasketItem.Product, ProductContract>();
            CreateMap<Basket.Domain.BasketItem.ProductMetadata, ProductMetadataContract>();
        }
    }
}