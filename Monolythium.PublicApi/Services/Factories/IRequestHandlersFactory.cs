using Monolythium.PublicApi.Services.Handlers;

namespace Monolythium.PublicApi.Services.Factories
{
    public interface IRequestHandlersFactory
    {
        CreateOrderHandler CreateCreateOrderHandler();
        CancelOrderHandler GetCancelOrderHandler();
    }
}
