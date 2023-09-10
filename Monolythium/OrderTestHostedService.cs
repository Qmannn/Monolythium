using MediatR;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Monolythium.PublicApi.CommandProcessing.Orders;

namespace Monolythium
{
    internal class OrderTestHostedService : BackgroundService
    {
        private readonly ILogger<OrderTestHostedService> _logger;
        private readonly IMediator _mediator;
        private readonly ISender _sender;
        private readonly IPublisher _publisher;


        public OrderTestHostedService(ILogger<OrderTestHostedService> logger, IMediator mediator, ISender sender, IPublisher publisher)
        {
            _logger = logger;
            _mediator = mediator;
            _sender = sender;
            _publisher = publisher;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("This is still works");
                await Task.Delay(5000, stoppingToken);

                var cmd = new CreateOrderCommand(42, "Maks");
                var id = await _mediator.Send(cmd);
                await _sender.Send(cmd);

                _logger.LogDebug($"Order {id} was created");
            }
        }
    }
}
