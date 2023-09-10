using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Monolythium.PublicApi.Controllers;

namespace Monolythium
{
    internal class OrderTestHostedService : BackgroundService
    {
        private readonly ILogger<OrderTestHostedService> _logger;
        private readonly IOrderController _orderController;

        public OrderTestHostedService(ILogger<OrderTestHostedService> logger, IOrderController orderController)
        {
            _logger = logger;
            _orderController = orderController;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(1000);
                _logger.LogInformation("This is still works");


                _orderController.CreateOrder(new PublicApi.Dto.CreateOrderRequestDto
                {
                    CustomerFullName = "Max",
                    OrderAmount = 100500
                });
            }
        }
    }
}
