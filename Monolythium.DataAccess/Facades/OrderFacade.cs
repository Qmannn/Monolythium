using Monolythium.DataAccess.Entities;

namespace Monolythium.DataAccess.Facades
{
    internal class OrderFacade : IOrderFacade
    {
        public Order GetOrder(int orderId)
        {
            // todo: some hard logic to get order from database

            return new Order
            {
                Id = orderId,
                TotalAmount = 42,
                CustomerFullName = "Jhon Doe"
            };
        }

        public int SaveOrder(Order order)
        {
            // todo: strong logic to save order

            return 42;
        }
    }
}
