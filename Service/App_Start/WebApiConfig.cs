using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;


namespace Service
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.EnableCors();
            config.Filters.Add(new AuthorizeAttribute());
            config.MessageHandlers.Add(new TokenValidationHandler());

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}",
                defaults: new {id = RouteParameter.Optional }
            );

        }


    }

}

