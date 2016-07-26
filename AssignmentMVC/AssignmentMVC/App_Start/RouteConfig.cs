using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AssignmentMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            /*          routes.MapRoute(
                          "/FeverCheck", "Home/{name}", 
                          new {Controller = "Home", action ="FeverCheck", name = UrlParameter.Optional });
          */


            routes.MapRoute(
               name: "FeverCheck",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Home", action = "FeverCheck", id = UrlParameter.Optional }
           );

  

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
