using Microsoft.Extensions.DependencyInjection;
using Monolythium.PublicApi.Controllers;
using Monolythium.PublicApi.Services.Handlers;

namespace Monolythium.PublicApi
{
    public static class PublicApiServiceCollectionExtensions
    {
        public static IServiceCollection AddPublicApi(this IServiceCollection services)
        {
            services.AddScoped<IOrderController, OrderController>();
            services.AddScoped<CreateOrderHandler>();

            // TODO: use MediatR instead of IRequestHandlersFactory

            return services;
        }
    }
}
