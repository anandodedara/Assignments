using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using Assignment_02.Models;
using NLog;

namespace Assignment_02.Controllers
{
    [HandleError]
    public class UsersController : Controller
    {
        private UsersDb db = new UsersDb();
        private static Logger logger = LogManager.GetCurrentClassLogger();


        
        // GET: Users
        public ActionResult Index()
        {
            if (Session["email"] != null && Session["id"] != null)
                return Welcome(Int16.Parse(Session["id"].ToString()));
            else
                return View("Login");
        }


        private User IsValid(string email, string password)
        {
            using (var db = new UsersDb())
            if(email!=null && password!=null)
            {
                String encPassword = GetMD5(password);
                var user = db.Users.FirstOrDefault(u => u.Email == email && u.Password.Equals(encPassword));
                    if (user != null) {
                        logger.Info("Already logged in."+user.Email+" | Session ID= "+Session.SessionID + Environment.NewLine + DateTime.Now);
                        return user;
                    }
                    else
                        logger.Error("Login Failed!"+ email + Environment.NewLine + DateTime.Now);
                    
            }
            return null;
        }

        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {
            User validate = IsValid(user.Email, user.Password);
            if (validate!=null)
            {
                Session["UserFullName"] = validate.FirstName + " " + validate.LastName;
                Session["email"] = user.Email;
                Session["id"] = validate.ID;
                
                return RedirectToAction("Index");

            }
            else
            {
                ModelState.AddModelError("error","Incorrect credentials!");
            }
            return View("Login",user);
        }

        // GET: Users/Details/5
        [HttpPost]
        public ActionResult Welcome(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View("UserProfile",user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,LastName,Email,Mobile,DateOfBirth,Password")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);

                user.Password = GetMD5(user.Password);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit()
        {
            try
            {
                int id = Int16.Parse(Session["id"].ToString());
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                User user = db.Users.Find(id);
                if (user == null)
                {
                    return HttpNotFound();
                }
                return View(user);
            }
            catch (Exception exc) {
                logger.Error(exc);
                return RedirectToAction("Index");
            }
            
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,LastName,Email,Mobile,DateOfBirth,Password")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        
        public ActionResult Logout() {
            Session.Clear();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }




        //create a string MD5
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }

    }
}
