using Monolythium.Core.OrderProcessing;
using Monolythium.DataAccess;
using Monolythium.DependencyManagement;
using Monolythium.PublicApi.Controllers;
using Monolythium.PublicApi.Services.Factories;
using Monolythium.PublicApi.Services.Handlers;
using Ninject.Extensions.Factory;

namespace Monolythium.PublicApi
{
    public class PublicApiModule : BaseDependencyModule
    {
        public override IEnumerable<BaseDependencyModule> GetDependencies()
        {
            return new[]
            {
                new OrderProcessingModule(),
                (BaseDependencyModule)new DataAccessModule()
            };
        }

        public override void Load()
        {
            Bind<IOrderController>().To<OrderController>().InLocalScope(BindingScopeStrategy);

            Bind<CreateOrderHandler>().To<CreateOrderHandler>().InLocalScope(BindingScopeStrategy);
            Bind<CancelOrderHandler>().ToSelf().InLocalScope(BindingScopeStrategy);

            Bind<IRequestHandlersFactory>().ToFactory();
        }
    }
}
