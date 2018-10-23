using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Service
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "Default",
                url: "api/{controller}/{action}/{id}",
                defaults: new { id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Route1",
                url: "api/{controller}/{action}/{UserName}/{Password}/{EmailAddress}/{PhoneNumber}/{City}/{Address}/{Country}",
                defaults: new {Password=UrlParameter.Optional,EmailAddress=UrlParameter.Optional,PhoneNumber=UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Route2",
                url: "api/{controller}/{action}/{id}",
                defaults: new { id = UrlParameter.Optional}
            );
            routes.MapRoute(
                name: "Route3",
                url: "api/{controller}/{action}/{userName}/{password}"
            );


        }
        protected void Application_Start()
        {
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

    }
}
