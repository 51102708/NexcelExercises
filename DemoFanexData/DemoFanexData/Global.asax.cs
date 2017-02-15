using Fanex.Data;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace DemoFanexData
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            DbSettingProviderManager
              .StartNewSession()
              .UseDefaultConnectionStringProvider()
              .UseDefaultDbSettingProvider(
                resourcePath: "~/App_Data/northwindSP.xml",
                ignoreRedundantParameters: false,
                enableWatching: true)
              .Run();
        }
    }
}