using Monolythium.DataAccess;
using Monolythium.DependencyManagement;

namespace Monolythium.Core.OrderProcessing
{
    public class OrderProcessingModule : BaseDependencyModule
    {
        public override IEnumerable<BaseDependencyModule> GetDependencies()
        {
            return new[] { new DataAccessModule() };
        }

        public override void Load()
        {
            Bind<IOrderMaker>().To<OrderMaker>();
            Bind<IOrderAnnihilator>().To<OrderAnnihilator>();
        }
    }
}
