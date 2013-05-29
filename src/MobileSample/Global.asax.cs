using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.WebPages;

namespace MobileSample
{
    // 注意: 如需啟用 IIS6 或 IIS7 傳統模式的說明，
    // 請造訪 http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            DisplayModeProvider.Instance.Modes.Insert(0, new DefaultDisplayMode("iPhone")
            {
                ContextCondition = (context => context.Request.UserAgent.IndexOf
                    ("iPhone", StringComparison.OrdinalIgnoreCase) >= 0)
            });

            DisplayModeProvider.Instance.Modes.Insert(0, new DefaultDisplayMode("WP7")
            {
                ContextCondition = (context => context.GetOverriddenUserAgent().IndexOf
                    ("Windows Phone OS", StringComparison.OrdinalIgnoreCase) >= 0)
            });
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            BundleMobileConfig.RegisterBundles(BundleTable.Bundles);

        }
    }
}