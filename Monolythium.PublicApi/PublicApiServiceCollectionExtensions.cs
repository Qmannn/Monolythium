using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Monolythium.PublicApi.CommandProcessing.Orders;

namespace Monolythium.PublicApi
{
    public static class PublicApiServiceCollectionExtensions
    {
        public static IServiceCollection AddPublicApi(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<CreateOrderCommand>());

            return services;
        }
    }
}
