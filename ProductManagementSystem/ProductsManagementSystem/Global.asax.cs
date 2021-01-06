
using ProductsManagementSystem.App_Start;
using System;
using System.IO;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ProductsManagementSystem
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            
            var BaseDirectory = new DirectoryInfo(Server.MapPath("~")).Parent;
            AppDomain.CurrentDomain.SetData("DataDirectory", BaseDirectory.FullName);
            AreaRegistration.RegisterAllAreas();
            UnityConfig.RegisterComponents();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            
            
        }
    }
}
