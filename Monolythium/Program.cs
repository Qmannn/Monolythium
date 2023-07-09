using Monolythium.PublicApi;
using Monolythium.PublicApi.Controllers;
using Ninject;

Console.WriteLine("Hello, World!");

var kernel = new StandardKernel();
kernel.Load(new PublicApiModule());

var controller = kernel.Get<IOrderController>();

controller.CreateOrder(new Monolythium.PublicApi.Dto.CreateOrderRequestDto
{
    CustomerFullName = null,
    OrderAmount = 0
});