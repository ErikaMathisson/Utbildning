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

       /*     routes.MapRoute(
                name: "DeletePeople",
                url: "People",
                defaults: new { Controller = "People", action = "Delete", name = UrlParameter.Optional });
*/
            routes.MapRoute(
                name: "GuessingGame",
                url: "GuessingGame",
                defaults: new { Controller = "GuessingGame", action = "GuessingGame", name = UrlParameter.Optional } );

            routes.MapRoute(
                name:"Fever",
                url: "FeverCheck",
                defaults: new { Controller = "FeverCheck", action = "FeverCheck", name = UrlParameter.Optional });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional } );
        }
    }
}
