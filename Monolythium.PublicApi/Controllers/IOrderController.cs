using Monolythium.PublicApi.Dto;

namespace Monolythium.PublicApi.Controllers
{
    public interface IOrderController
    {
        void CancelOrder(int orderId);
        void CreateOrder(CreateOrderRequestDto createOrderRequestDto);
    }
}