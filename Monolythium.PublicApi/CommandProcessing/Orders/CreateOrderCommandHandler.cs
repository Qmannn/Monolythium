using MediatR;
using Monolythium.Core.OrderProcessing;
using Monolythium.DataAccess.Entities;

namespace Monolythium.PublicApi.CommandProcessing.Orders
{
    internal class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int>
    {
        private readonly IOrderMaker _orderMaker;

        public CreateOrderCommandHandler(IOrderMaker orderMaker)
        {
            _orderMaker = orderMaker;
        }

        public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            await Task.Delay(500);

            Order order = _orderMaker.MakeOrder(request.OrderAmount, request.CustomerFullName);

            return order.Id;
        }
    }
}
