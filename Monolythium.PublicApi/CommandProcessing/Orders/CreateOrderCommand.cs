using MediatR;

namespace Monolythium.PublicApi.CommandProcessing.Orders
{
    public class CreateOrderCommand: IRequest<int>
    {
        public decimal OrderAmount { get; }
        public string CustomerFullName { get; }

        public CreateOrderCommand(decimal orderAmount, string customerFullName)
        {
            OrderAmount = orderAmount;
            CustomerFullName = customerFullName;
        }
    }
}
