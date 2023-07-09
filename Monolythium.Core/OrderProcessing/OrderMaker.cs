using Monolythium.DataAccess.Entities;
using Monolythium.DataAccess.Facades;

namespace Monolythium.Core.OrderProcessing
{
    internal class OrderMaker : IOrderMaker
    {
        private readonly IOrderFacade _orderFacade;

        public OrderMaker(IOrderFacade orderFacade)
        {
            _orderFacade = orderFacade;
        }

        public Order MakeOrder(decimal totalAmount, string customerFullName)
        {
            if (String.IsNullOrEmpty(customerFullName))
            {
                throw new ArgumentNullException(nameof(customerFullName));
            }

            if (totalAmount <= 0)
            {
                throw new ArgumentException(nameof(totalAmount));
            }

            Order order = new Order
            {
                TotalAmount = totalAmount,
                CustomerFullName = customerFullName,
                Status = OrderStatus.Active
            };

            int createdOrderId = _orderFacade.SaveOrder(order);

            return _orderFacade.GetOrder(createdOrderId);
        }
    }
}
