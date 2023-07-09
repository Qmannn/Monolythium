using Monolythium.PublicApi.Dto;
using Monolythium.PublicApi.Services.Factories;

namespace Monolythium.PublicApi.Controllers
{
    internal class OrderController : IOrderController
    {
        private readonly IRequestHandlersFactory _requestHandlersFactory;

        public OrderController(IRequestHandlersFactory requestHandlersFactory)
        {
            _requestHandlersFactory = requestHandlersFactory;
        }

        public void CreateOrder(CreateOrderRequestDto createOrderRequestDto)
        {
            _requestHandlersFactory.CreateCreateOrderHandler().CreateOrder(createOrderRequestDto);
        }

        public void CancelOrder(int orderId)
        {
            _requestHandlersFactory.GetCancelOrderHandler().CancelOrder(orderId);
        }
    }
}
