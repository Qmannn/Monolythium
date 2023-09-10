using MediatR;

namespace Monolythium.PublicApi.CommandProcessing.Orders
{
    public class CancelOrderCommand: IRequest
    {
        public int OrderId { get; }

        public CancelOrderCommand(int orderId)
        {
            OrderId = orderId;
        }
    }
}
