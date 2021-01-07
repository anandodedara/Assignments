using NLog;
using System;
using System.IO;
using System.Web.Mvc;
using System.Web.Routing;

namespace ProductsManagementSystem
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public readonly Logger logger = NLog.LogManager.GetCurrentClassLogger();
        protected void Application_Start()
        {
            

            var BaseDirectory = new DirectoryInfo(Server.MapPath("~")).Parent;
            AppDomain.CurrentDomain.SetData("DataDirectory", BaseDirectory.FullName);
            AreaRegistration.RegisterAllAreas();
            UnityConfig.RegisterComponents();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            var ex = Server.GetLastError();
            if(ex!=null)
                logger.Error("ERROR::",ex,ex.Data);
            
        }
    }
}
