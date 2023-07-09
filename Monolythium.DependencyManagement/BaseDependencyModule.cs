using Ninject.Modules;
using Ninject.Syntax;

namespace Monolythium.DependencyManagement
{
    public abstract class BaseDependencyModule : NinjectModule
    {
        private BindingScopeStrategy? _bindingScopeStrategy;
        protected BindingScopeStrategy BindingScopeStrategy => _bindingScopeStrategy ?? throw new NullReferenceException("BindingScopeStartegy must be defined before usage");

        public virtual IEnumerable<BaseDependencyModule> GetDependencies()
        {
            return new BaseDependencyModule[0];
        }

        public IEnumerable<INinjectModule> GetModulesForCompositionRoot(BindingScopeStrategy? bindingScopeStrategy = null)
        {
            HashSet<BaseDependencyModule> uniqueDependencies = new HashSet<BaseDependencyModule>(new BaseDependencyModuleEqualityComparer());
            VisitAllDependencies(uniqueDependencies);

            BindingScopeStrategy selectedBindingScopeStrategy = bindingScopeStrategy ?? new BindingScopeStrategy();

            foreach (var module in uniqueDependencies)
            {
                module.DefineBindingScopeStrategy(selectedBindingScopeStrategy);
            }

            return uniqueDependencies;
        }

        private void VisitAllDependencies(HashSet<BaseDependencyModule> visitedDependencies)
        {
            visitedDependencies.Add(this);
            foreach (BaseDependencyModule dependency in GetDependencies())
            {
                if (visitedDependencies.Add(dependency))
                {
                    dependency.VisitAllDependencies(visitedDependencies);
                }
            }
        }

        private void DefineBindingScopeStrategy(BindingScopeStrategy bindingScopeStrategy)
        {
            if (_bindingScopeStrategy is not null)
            {
                throw new InvalidOperationException($"{nameof(BindingScopeStrategy)} can't be changed");
            }

            _bindingScopeStrategy = bindingScopeStrategy;
        }
    }
}