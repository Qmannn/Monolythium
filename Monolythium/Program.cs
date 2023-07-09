using Monolythium;
using Monolythium.DependencyManagement;
using Monolythium.PublicApi;
using Monolythium.PublicApi.Controllers;
using Ninject;


BaseDependencyModule rootModule1 = new PublicApiModule();

var singletonKernel = new StandardKernel();
singletonKernel.Load(rootModule1.GetModulesForCompositionRoot(new SingletonBindingStrategy()));

BaseDependencyModule rootModule2 = new PublicApiModule();
var transientKernel = new StandardKernel();
transientKernel.Load(rootModule2.GetModulesForCompositionRoot(new TransientBindingStrategy()));

MakeTwoControlelrs(singletonKernel, true);
MakeTwoControlelrs(transientKernel, false);

var controller = transientKernel.Get<IOrderController>();

controller.CreateOrder(new Monolythium.PublicApi.Dto.CreateOrderRequestDto
{
    CustomerFullName = "Max",
    OrderAmount = 100500
});

void MakeTwoControlelrs(IKernel kernel, bool shouldBeEquals)
{
    var controller1 = kernel.Get<IOrderController>();
    var controller2 = kernel.Get<IOrderController>();

    bool isControllerInstancesEquals = ReferenceEquals(controller1, controller2);

    if (isControllerInstancesEquals != shouldBeEquals)
    {
        throw new InvalidOperationException("Binding strategy doesn't work");
    }
}