using System;
using StructureMap;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;

namespace Demos.Web.Dependencies.DependencyResolution.Registries
{
    public class MvcRegistry : Registry
    {
        public MvcRegistry()
        {
            Scan(
                scan =>
                {
                    //assemblies
                    scan.AssembliesFromApplicationBaseDirectory(assembly =>
                    {
                        var name = assembly.GetName().Name;
                        return name.StartsWith("Demos", StringComparison.OrdinalIgnoreCase);
                    });

                    //scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                    scan.With(new ControllerConvention());
                });
        }

    }
}