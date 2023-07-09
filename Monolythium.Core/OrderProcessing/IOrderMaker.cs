using Monolythium.DataAccess.Entities;

namespace Monolythium.Core.OrderProcessing
{
    public interface IOrderMaker
    {
        Order MakeOrder(decimal totalAmount, string customerFullName);
    }
}