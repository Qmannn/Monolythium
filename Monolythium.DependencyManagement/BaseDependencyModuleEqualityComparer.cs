using System.Diagnostics.CodeAnalysis;

namespace Monolythium.DependencyManagement
{
    internal class BaseDependencyModuleEqualityComparer : IEqualityComparer<BaseDependencyModule>
    {
        public bool Equals(BaseDependencyModule? x, BaseDependencyModule? y)
        {
            if (ReferenceEquals(x, y))
            {
                return true;
            }

            if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
            {
                return false;
            }
            
            return x.GetType().Equals(y.GetType());
        }

        public int GetHashCode([DisallowNull] BaseDependencyModule obj)
        {
            return obj.GetType().GetHashCode();
        }
    }
}
