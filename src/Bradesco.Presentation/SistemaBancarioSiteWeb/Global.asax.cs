using CQRSlite.Config;
using SistemaBancarioSiteWeb.App_Start;
using System.Web.Mvc;
using System.Web.Routing;

namespace SistemaBancarioSiteWeb
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            ServiceLocatorConfig.Initialize();
        }
    }
}
