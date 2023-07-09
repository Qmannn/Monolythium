using Monolythium.DependencyManagement;
using Monolythium.PublicApi;
using Monolythium.PublicApi.Controllers;
using Monolythium.PublicApi.Services.Factories;
using Monolythium.PublicApi.Services.Handlers;
using Ninject;
using Ninject.Modules;

Console.WriteLine("Hello, World!");

var kernel = new StandardKernel();
BaseDependencyModule rootModule = new PublicApiModule();

IEnumerable<INinjectModule> modules = rootModule.GetModulesForCompositionRoot();

kernel.Load(modules);

var handler = kernel.Get<IRequestHandlersFactory>();
handler.CreateCreateOrderHandler();

var controller = kernel.Get<IOrderController>();

controller.CreateOrder(new Monolythium.PublicApi.Dto.CreateOrderRequestDto
{
    CustomerFullName = "Max",
    OrderAmount = 100500
});