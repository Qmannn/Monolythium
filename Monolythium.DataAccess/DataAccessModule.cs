using Monolythium.DataAccess.Facades;
using Ninject.Modules;
using Ninject.Syntax;

namespace Monolythium.DataAccess
{
    public class DataAccessModule : NinjectModule
    {
        public override void Load()
        {
            // TODO: all services are registered use transient strategy. I would like to make customize strategy

            Bind<IOrderFacade>().To<OrderFacade>();
        }
    }
}
