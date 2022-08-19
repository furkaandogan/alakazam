using Microsoft.Extensions.DependencyInjection;
using Alakazam.Framework;
using Alakazam.Basket.Domain.Commands;
using AutoMapper;
using Alakazam.Basket.Application.Mappings;
using Alakazam.Basket.Application.Usecases.GetBasket;
using Alakazam.Basket.Application.Adapters.Product;
using Alakazam.Basket.Application.Usecases.AddProductToBasket;

namespace Alakazam.Basket.Application
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection SetupApp(this IServiceCollection services)
        {
            return services
                .SetupCommandHandler()
                .SetupMappings();
        }

        private static IServiceCollection SetupCommandHandler(this IServiceCollection services)
        {
            services.AddSingleton<ICommandHandler<GetBasketCommand, GetBasketCommandResult>, GetBasketCommandHandler>();
            services.AddSingleton<ICommandHandler<BasketAddProductCommand, AddProductToBasketCommandResult>, AddProductToBasketCommandHandler>();
            return services;
        }

        private static IServiceCollection SetupMappings(this IServiceCollection services)
        {
            return services.AddAutoMapper(cfg =>{
                cfg.AddProfile<BasketContractProfile>();
            });
        }
    }
}