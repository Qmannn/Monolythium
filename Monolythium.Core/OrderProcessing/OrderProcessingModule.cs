using Monolythium.DataAccess;
using Ninject.Modules;

namespace Monolythium.Core.OrderProcessing
{
    public class OrderProcessingModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Load(new[] { new DataAccessModule() });

            Bind<IOrderMaker>().To<OrderMaker>();
            Bind<IOrderAnnihilator>().To<OrderAnnihilator>();

        }
    }
}
