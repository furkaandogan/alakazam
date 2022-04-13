using Microsoft.Extensions.DependencyInjection;
using Alakazam.Basket.Domain;
using Alakazam.Basket.Infrastructure.Adapters.Product;
using Alakazam.Basket.Application.Adapters.Product;

namespace Alakazam.Basket.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection SetupInfra(this IServiceCollection services)
        {
            return services
                .SetupRepository()
                .SetupAdaptor();
        }
        private static IServiceCollection SetupAdaptor(this IServiceCollection services)
        {
            services.AddSingleton<IProductAdapter, ProductApiAdapter>();
            return services;
        }
        private static IServiceCollection SetupRepository(this IServiceCollection services)
        {
            services.AddSingleton<IBasketCommandRepository,BasketInMemoryCommandRepository>();
            services.AddSingleton<IBasketQueryRepository,BasketInMemoryQueryRepository>();
            services.AddSingleton<InMemoryContext, InMemoryContext>();
            return services;
        }
    }
}