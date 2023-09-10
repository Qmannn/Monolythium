using Monolythium.Core.OrderProcessing;
using Monolythium.DataAccess;
using Monolythium.PublicApi;

namespace Monolythium.Api
{
    internal static class CompositionRootServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationRoot(this IServiceCollection services)
        {
            services.AddDataAccess();
            services.AddOrderProcessing();
            services.AddPublicApi();

            return services;
        }
    }
}
