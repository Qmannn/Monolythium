using Monolythium.DependencyManagement;
using Ninject.Syntax;

namespace Monolythium
{
    internal class SingletonBindingStrategy: BindingScopeStrategy
    {
        public override IBindingNamedWithOrOnSyntax<T> InLocalScope<T>(IBindingInSyntax<T> action)
        {
            return action.InSingletonScope();
        }
    }
}
