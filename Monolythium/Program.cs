using Monolythium.DependencyManagement;
using Monolythium.PublicApi;
using Monolythium.PublicApi.Controllers;
using Ninject;

var kernel = new StandardKernel();
BaseDependencyModule rootModule = new PublicApiModule();
kernel.Load(rootModule.GetModulesForCompositionRoot());

var controller = kernel.Get<IOrderController>();

controller.CreateOrder(new Monolythium.PublicApi.Dto.CreateOrderRequestDto
{
    CustomerFullName = "Max",
    OrderAmount = 100500
});