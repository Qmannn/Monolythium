using Monolythium.DataAccess.Entities;

namespace Monolythium.Core.OrderProcessing
{
    public interface IOrderAnnihilator
    {
        void CancelOrder(Order order);
    }
}