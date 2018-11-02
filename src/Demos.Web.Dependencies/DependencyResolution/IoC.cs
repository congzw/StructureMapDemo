using System.Diagnostics;
using CommonServiceLocator;
using Demos.Common.Ioc;
using StructureMap;

namespace Demos.Web.Dependencies.DependencyResolution
{
    public static class IoC
    {
        public static IContainer Initialize()
        {
            var container = new Container(c =>
            {
                c.Scan(_ =>
                {
                    //assemblies
                    _.AssembliesAndExecutablesFromApplicationBaseDirectory(assembly =>
                    {
                        var name = assembly.GetName().Name;
                        return name.StartsWith("Demos");
                    });

                    //registries
                    _.LookForRegistries();
                });

                //global register
                c.For<IServiceLocator>().Use<StructureMapDependencyScope>().Singleton();
            });

            CoreServiceProvider.CurrentFunc = () => container.GetInstance<IServiceLocator>();

            ShowDebugInfo(container);

            return container;
        }

        private static void ShowDebugInfo(Container container)
        {
            var whatDidIScan = container.WhatDidIScan();
            Debug.Write(whatDidIScan);

            var whatDoIHave = container.WhatDoIHave();
            Debug.Write(whatDoIHave);
        }
    }
}