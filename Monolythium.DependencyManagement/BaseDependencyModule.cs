using Ninject.Modules;

namespace Monolythium.DependencyManagement
{
    public abstract class BaseDependencyModule : NinjectModule
    {
        public virtual IEnumerable<BaseDependencyModule> GetDependencies()
        {
            return new BaseDependencyModule[0];
        }

        public IEnumerable<INinjectModule> GetModulesForCompositionRoot()
        {
            HashSet<BaseDependencyModule> uniqueDependencies = new HashSet<BaseDependencyModule>(new BaseDependencyModuleEqualityComparer());
            VisitAllDependencies(uniqueDependencies);
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
    }
}