using System.Web.Mvc;

namespace MVCUI.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { controler="Home", action = "Index", id = UrlParameter.Optional },
                new[] { "MVCUI.Areas.Admin.Controllers" } // ön yüz ve admindeki controller çakışmalarını engellemek için
            );
        }
    }
}