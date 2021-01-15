using Microsoft.AspNetCore.Cors;
using System.Web.Http;
using System.Web.Mvc;

namespace HMS.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling
                = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

           

            config.Formatters.Remove(config.Formatters.XmlFormatter); //To return JSON only



            // Web API routes
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { controller="Hotel", action= "GetAllHotels", id = RouteParameter.Optional }
            );
        }
    }
}
