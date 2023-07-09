using Monolythium.DataAccess.Facades;
using Monolythium.DependencyManagement;

namespace Monolythium.DataAccess
{
    public class DataAccessModule : BaseDependencyModule
    {
        public override void Load()
        {
            Bind<IOrderFacade>().To<OrderFacade>().InLocalScope(BindingScopeStrategy);
        }
    }
}
