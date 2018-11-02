using System;
using StructureMap;

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
                    scan.AssembliesAndExecutablesFromApplicationBaseDirectory(assembly =>
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