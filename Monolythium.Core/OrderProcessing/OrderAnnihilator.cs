using Monolythium.DataAccess.Entities;
using Monolythium.DataAccess.Facades;

namespace Monolythium.Core.OrderProcessing
{
    internal class OrderAnnihilator : IOrderAnnihilator
    {
        private readonly IOrderFacade _orderFacade;

        public OrderAnnihilator(IOrderFacade orderFacade)
        {
            _orderFacade = orderFacade;
        }

        public void CancelOrder(Order order)
        {
            if (order.Status != OrderStatus.Active)
            {
                throw new InvalidOperationException("Order must be active");
            }

            order.Status = OrderStatus.Cancelled;

            _orderFacade.SaveOrder(order);
        }
    }
}
