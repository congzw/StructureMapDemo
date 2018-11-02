using System.Web.Http.Dependencies;
using StructureMap;

namespace Demos.Web.Dependencies.DependencyResolution
{
    public class StructureMapWebApiDependencyScope : StructureMapDependencyScope, IDependencyScope
    {
        public StructureMapWebApiDependencyScope(IContainer container)
            : base(container) {
        }
    }
}
