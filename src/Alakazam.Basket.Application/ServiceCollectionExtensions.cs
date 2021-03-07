using Microsoft.Extensions.DependencyInjection;
using Alakazam.Framework;
using Alakazam.Basket.Domain.Commands;
using Alakazam.Basket.Application.Usecases.BasketAddProduct;
using AutoMapper;
using Alakazam.Basket.Application.Mappings;
using Alakazam.Basket.Infrastructure;
using Alakazam.Basket.Domain;
using Alakazam.Basket.Infrastructure.Adapters.Product;
using Alakazam.Basket.Application.Usecases.GetBasket;

namespace Alakazam.Basket.Application
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection SetupApp(this IServiceCollection services)
        {
            return services
                .SetupRepository()
                .SetupAdaptor()
                .SetupCommandHandler()
                .SetupMappings();
        }

        private static IServiceCollection SetupCommandHandler(this IServiceCollection services)
        {
            services.AddSingleton<ICommandHandler<BasketAddProductCommand, BasketAddProductCommandResult>,BasketAddProductCommandHandler>();
            services.AddSingleton<ICommandHandler<GetBasketCommand, GetBasketCommandResult>, GetBasketCommandHandler>();
            return services;
        }
        private static IServiceCollection SetupAdaptor(this IServiceCollection services)
        {
            services.AddSingleton<ProductApiAdapter, ProductApiAdapter>();
            return services;
        }
        private static IServiceCollection SetupRepository(this IServiceCollection services)
        {
            services.AddSingleton<IBasketCommandRepository,BasketInMemoryCommandRepository>();
            services.AddSingleton<IBasketQueryRepository,BasketInMemoryQueryRepository>();
            services.AddSingleton<InMemoryContext, InMemoryContext>();
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