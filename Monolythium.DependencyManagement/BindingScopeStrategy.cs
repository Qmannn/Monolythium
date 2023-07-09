using Ninject.Syntax;

namespace Monolythium.DependencyManagement
{
    /// <summary>
    /// Strategy for define local scope bindings (e.g. named scope / perThread or per HttpRequest) in depend on composition root
    /// </summary>
    public class BindingScopeStrategy
    {
        public virtual IBindingNamedWithOrOnSyntax<T> InLocalScope<T>(IBindingInSyntax<T> action)
        {
            return action.InThreadScope();
        }
    }
}
