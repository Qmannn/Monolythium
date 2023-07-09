using Monolythium.DataAccess.Facades;
using Monolythium.DependencyManagement;

namespace Monolythium.DataAccess
{
    public class DataAccessModule : BaseDependencyModule
    {
        public override void Load()
        {
            // TODO: all services are registered use transient strategy. I would like to make customize strategy

            Bind<IOrderFacade>().To<OrderFacade>();
        }
    }
}
