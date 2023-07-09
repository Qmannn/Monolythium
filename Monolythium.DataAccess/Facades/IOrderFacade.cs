using Monolythium.DataAccess.Entities;

namespace Monolythium.DataAccess.Facades
{
    public interface IOrderFacade
    {
        Order GetOrder(int orderId);

        int SaveOrder(Order order);
    }
}