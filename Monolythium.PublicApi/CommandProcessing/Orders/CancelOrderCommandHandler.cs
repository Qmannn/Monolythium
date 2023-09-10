using MediatR;
using Monolythium.Core.OrderProcessing;
using Monolythium.DataAccess.Entities;
using Monolythium.DataAccess.Facades;

namespace Monolythium.PublicApi.CommandProcessing.Orders
{
    internal class CancelOrderCommandHandler : IRequestHandler<CancelOrderCommand>
    {
        private readonly IOrderFacade _orderFacade;
        private readonly IOrderAnnihilator _orderAnnihilator;

        public CancelOrderCommandHandler(IOrderFacade orderFacade, IOrderAnnihilator orderAnnihilator)
        {
            _orderFacade = orderFacade;
            _orderAnnihilator = orderAnnihilator;
        }

        public async Task Handle(CancelOrderCommand request, CancellationToken cancellationToken)
        {
            await Task.Delay(500);

            Order order = _orderFacade.GetOrder(request.OrderId);
            _orderAnnihilator.CancelOrder(order);
        }
    }
}
