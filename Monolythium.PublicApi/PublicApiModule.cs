using Monolythium.Core.OrderProcessing;
using Monolythium.DataAccess;
using Monolythium.PublicApi.Controllers;
using Monolythium.PublicApi.Services.Factories;
using Monolythium.PublicApi.Services.Handlers;
using Ninject.Extensions.Factory;
using Ninject.Modules;

namespace Monolythium.PublicApi
{
    public class PublicApiModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Load(new[] {
                (INinjectModule)new OrderProcessingModule(),
                (INinjectModule)new DataAccessModule() });

            Bind<IOrderController>().To<OrderController>();

            Bind<CreateOrderHandler>();
            Bind<CancelOrderHandler>();

            Bind<IRequestHandlersFactory>().ToFactory();
        }
    }
}
