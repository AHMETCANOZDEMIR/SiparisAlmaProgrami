using System.Web.Mvc;
using System.Web.Routing;

namespace MVCUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes(); // Controller larda Route attribute u kullanabilmek için bu kodu buraya eklememiz gerekiyor!

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new[] { "MVCUI.Controllers" } // admin ve ön yüzdeki home controller ların çakışması durumunda oluşacak hatayı engellemek için ekledik!
            );
        }
    }
}
