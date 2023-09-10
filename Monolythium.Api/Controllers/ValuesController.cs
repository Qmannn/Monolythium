using MediatR;
using Microsoft.AspNetCore.Mvc;
using Monolythium.PublicApi.CommandProcessing.Orders;

namespace Monolythium.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ISender _sender;

        public ValuesController(IMediator mediator, ISender sender)
        {
            _mediator = mediator;
            _sender = sender;
        }

        [HttpGet("list")]
        public async Task<string> GetValues()
        {
            var cmd = new CreateOrderCommand(42, "Maks");

            var id = await _mediator.Send(cmd);
            await _sender.Send(cmd);

            return $"1,2,3, {id}";
        }
    }
}
