﻿using System.Web.Http;
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


            config.EnableCors();
            config.Formatters.Remove(config.Formatters.XmlFormatter);



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
