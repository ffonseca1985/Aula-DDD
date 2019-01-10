using System.Web.Mvc;

namespace SistemaBancarioSiteWeb.Areas.Acessos
{
    public class AcessosAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Acessos";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Acessos_default",
                "Acessos/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}