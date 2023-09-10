using Microsoft.Extensions.DependencyInjection;

namespace Monolythium.Core.OrderProcessing
{
    public static class OrderProcessingServiceCollectionExtensions
    {
        public static IServiceCollection AddOrderProcessing(this IServiceCollection services)
        {
            services.AddScoped<IOrderMaker, OrderMaker>();
            services.AddScoped<IOrderAnnihilator, OrderAnnihilator>();

            return services;
        }
    }
}
