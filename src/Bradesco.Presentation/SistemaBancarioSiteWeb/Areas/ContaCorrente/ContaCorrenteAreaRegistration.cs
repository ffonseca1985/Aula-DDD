using System.Web.Mvc;

namespace SistemaBancarioSiteWeb.Areas.ContaCorrente
{
    public class ContaCorrenteAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ContaCorrente";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "ContaCorrente_default",
                "ContaCorrente/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}