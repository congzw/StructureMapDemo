using System.Web;
using Demos.Common;
using Demos.Common.Data;
using StructureMap.Web.Pipeline;

namespace Demos.Web.Dependencies.DependencyResolution
{
    public class StructureMapScopeModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.BeginRequest += (sender, e) =>
            {
                StructuremapMvc.StructureMapDependencyScope.CreateNestedContainer();
                var transactionManager = StructuremapMvc.StructureMapDependencyScope.GetInstance<ITransactionManager>();
                //lazy mode, no need start tx;
                LogMessage("BeginRequest: " + transactionManager.GetHashCode());
            };
            context.EndRequest += (sender, e) =>
            {
                HttpContextLifecycle.DisposeAndClearAll();
                StructuremapMvc.StructureMapDependencyScope.DisposeNestedContainer();
                LogMessage("EndRequest");
            };

            context.Error += (sender, args) =>
            {
                //not work for webapi, use WebApiTransactionFilter
                var transactionManager = StructuremapMvc.StructureMapDependencyScope.GetInstance<ITransactionManager>();
                transactionManager.Cancel();
                LogMessage("Request Ex: transactionManager.Cancel()");
            };
        }
        public void Dispose()
        {
        }
        private void LogMessage(string message)
        {
            UtilsLogger.LogMessage(this.GetType(), message);
        }
    }
}