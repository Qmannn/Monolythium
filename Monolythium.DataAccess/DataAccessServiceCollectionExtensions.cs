using Microsoft.Extensions.DependencyInjection;
using Monolythium.DataAccess.Facades;

namespace Monolythium.DataAccess
{
    public static class DataAccessServiceCollectionExtensions
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services)
        {
            services.AddScoped<IOrderFacade, OrderFacade>();

            return services;
        }
    }
}
