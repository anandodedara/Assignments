using PMS.BLL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ProductsManagementSystem.Controllers
{
    [HandleError]
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
                FormsAuthentication.SetAuthCookie(user.Email,false);
                Session["UserDetails"] = validateUser;
                
                return RedirectToAction("Index","Products");
            }
            else
            {
                TempData["message"] = "Login Failed! Please enter valid credentials.";

                return View(user);
            }
        }

        public ActionResult Logout() {
            FormsAuthentication.SignOut();
            Session.Clear();
            TempData["message"] = "LogOut Successful.";
            TempData["messageType"] = "success";
            return RedirectToAction("Index","Products");
        }

        public ActionResult SignUp() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(PMS.Models.User user) {
            if (ModelState.IsValid)
            {
                _userManager.RegisterNewUser(user);
                TempData["message"] = "Registration Successful.";
                TempData["messageType"] = "success";
                
                return RedirectToAction("Login");
            }
            else
            {
                return View(user);
            }

            
        }
    }
}