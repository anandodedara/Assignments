using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductsManagementSystem.Controllers
{
    public class ErrorController : Controller
    {
        

        public ActionResult NotFound()
        {
            
            return View();
        }

        public ActionResult BadRequest()
        {
            return View();
        }

        public ActionResult InternalError()
        {
            return View();
        }
    }
}