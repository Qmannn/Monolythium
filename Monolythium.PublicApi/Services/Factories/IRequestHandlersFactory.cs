using Monolythium.PublicApi.Services.Handlers;

namespace Monolythium.PublicApi.Services.Factories
{
    internal interface IRequestHandlersFactory
    {
        CreateOrderHandler GetCreateOrderHandler();
        CancelOrderHandler GetCancelOrderHandler();
    }
}
