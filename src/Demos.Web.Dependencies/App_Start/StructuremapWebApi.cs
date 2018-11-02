using System.Web.Http;
using Demos.Web.Dependencies;
using Demos.Web.Dependencies.DependencyResolution;

[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(StructuremapWebApi), "Start")]

namespace Demos.Web.Dependencies {
	public static class StructuremapWebApi {
		public static void Start() {
			var container = StructuremapMvc.StructureMapDependencyScope.Container;
			GlobalConfiguration.Configuration.DependencyResolver = new StructureMapWebApiDependencyResolver(container);
		}
	}
}