using System.Web.Mvc;

namespace SistemaBancarioSiteWeb.Areas.Emprestimos
{
    public class EmprestimosAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Emprestimos";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Emprestimos_default",
                "Emprestimos/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}