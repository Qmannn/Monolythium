using Ninject.Syntax;

namespace Monolythium.DependencyManagement
{
    public static class BindingInSyntaxExtensions
    {
        public static IBindingNamedWithOrOnSyntax<T> InLocalScope<T>(this IBindingInSyntax<T> action, BindingScopeStrategy bindingScopeStrategy)
        {
            return bindingScopeStrategy.InLocalScope(action);
        }
    }
}
