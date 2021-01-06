using PMS.BLL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ProductsManagementSystem.Controllers
{
    public class UsersController : Controller
    {

        private readonly IUserManager _userManager;

        public UsersController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        // GET: Users
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(PMS.Models.User user) {
            PMS.Models.User validateUser = _userManager.ValidateUser(user.Email,user.Password);
            if (validateUser != null)
            {
                FormsAuthentication.SetAuthCookie(user.Email,true);
                //ViewBag["user"] = user.FirstName + " " + user.LastName;
                return RedirectToAction("Index","Products");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Logout() {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index","Products");
        }
    }
}