using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Monolythium.PublicApi.Controllers;

namespace Monolythium.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IOrderController? _orderController;

        public ValuesController()
        {
            _orderController = null;
        }

        [HttpGet("list")]
        public string GetValues()
        {
            _orderController?.CreateOrder(new PublicApi.Dto.CreateOrderRequestDto { CustomerFullName = "maks", OrderAmount = 42 });

            return "1,2,3";
        }
    }
}
