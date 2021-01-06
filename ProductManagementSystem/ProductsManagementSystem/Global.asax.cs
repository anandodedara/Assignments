
using ProductsManagementSystem.App_Start;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ProductsManagementSystem
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            //int index = baseDir.IndexOf("TestResults");
            //string path = baseDir.Substring(0, index) + System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
            var BaseDirectory = new DirectoryInfo(Server.MapPath("~")).Parent;
            AppDomain.CurrentDomain.SetData("DataDirectory", BaseDirectory.FullName);

            AreaRegistration.RegisterAllAreas();
            UnityConfig.RegisterComponents();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            
        }
    }
}
