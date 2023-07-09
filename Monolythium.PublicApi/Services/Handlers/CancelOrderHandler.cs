using Monolythium.Core.OrderProcessing;
using Monolythium.DataAccess.Entities;
using Monolythium.DataAccess.Facades;

namespace Monolythium.PublicApi.Services.Handlers
{
    public class CancelOrderHandler
    {
        private readonly IOrderFacade _orderFacade;

        private readonly IOrderAnnihilator _orderAnnihilator;

        public CancelOrderHandler(IOrderFacade orderFacade, IOrderAnnihilator orderAnnihilator)
        {
            _orderFacade = orderFacade;
            _orderAnnihilator = orderAnnihilator;
        }

        public void CancelOrder(int orderId)
        {
            Order order = _orderFacade.GetOrder(orderId);
            _orderAnnihilator.CancelOrder(order);
        }
    }
}
