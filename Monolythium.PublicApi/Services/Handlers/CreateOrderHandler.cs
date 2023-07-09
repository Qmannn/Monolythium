using Monolythium.Core.OrderProcessing;
using Monolythium.DataAccess.Entities;
using Monolythium.PublicApi.Dto;

namespace Monolythium.PublicApi.Services.Handlers
{
    public class CreateOrderHandler
    {
        private readonly IOrderMaker _orderMaker;

        public CreateOrderHandler(IOrderMaker orderMaker)
        {
            _orderMaker = orderMaker;
        }

        public int CreateOrder(CreateOrderRequestDto createOrderRequestDto)
        {
            Order order =  _orderMaker.MakeOrder(createOrderRequestDto.OrderAmount, createOrderRequestDto.CustomerFullName);

            return order.Id;
        }
    }
}
