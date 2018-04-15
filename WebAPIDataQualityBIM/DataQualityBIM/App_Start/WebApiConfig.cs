using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace DataQualityBIM
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();



            config.Routes.MapHttpRoute(
                           name: "DefaultApir",
                           routeTemplate: "api/{controller}/{AllinCompleteData}");

            config.Routes.MapHttpRoute(
                           name: "DefaultApirr",
                           routeTemplate: "api/{controller}/{AllCompleteData}");

            config.Routes.MapHttpRoute(
               name: "DefaultApi",
               routeTemplate: "api/{controller}/{tag}",
               defaults: new { tag = RouteParameter.Optional });

           
            config.Routes.MapHttpRoute(
               name: "DefaultApicomplete",
               routeTemplate: "api/{controller}/{completedata}/{tag}",
               defaults: new { tag = RouteParameter.Optional }
           );

            config.Routes.MapHttpRoute(
               name: "DefaultApiincomplete",
               routeTemplate: "api/{controller}/{incompletedata}/{tag}",
               defaults: new { tag = RouteParameter.Optional }
           );
        }
    }
}