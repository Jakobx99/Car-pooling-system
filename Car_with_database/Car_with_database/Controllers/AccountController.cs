using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;
using Car_with_database.Models;

namespace Car_with_database.Controllers
{
    public class AccountController : Controller
    {

        // GET: Account
        //TODO:make POST
        public ActionResult EditAccount()
        {
            User use = (User)Session["User"];
            return View(use);
        }

        [HttpPost]
        public ActionResult CreateAccount(User user)
        {
            CarDatabaseEntities1 db = new CarDatabaseEntities1();

            User local = user;
            local.isDriver = true;
            db.User.Add(user);
            db.SaveChanges();
            Session["User"] = local;
            return RedirectToAction("AccountDetails");
        }
        public ActionResult CreateAccount()
        {
            return View();
        }
        public ActionResult AccountDetails()
        {
            User use1 = (User) Session["User"];
            return View(use1);
        }
        public ActionResult LoginAccount(string Username, string Password)
        {
            CarDatabaseEntities1 db = new CarDatabaseEntities1();

            User use1 = new User();

            var user = from m in db.User
                where m.userName == Username
                select m;

            use1 = user.First();
            if (use1.password == Password)
            {
                Session["User"] = use1;
                Session["LoggedIn"] = true;
                return RedirectToAction("Index", "Home");
            }
            return Login();
        }
        public ActionResult Login()
        {
            return View("Login");
        }
        [HttpPost]
        public ActionResult LogOff()
        {
            Session["LoggedIn"] = false;
            Session["User"] = null;
            return RedirectToAction("Index", "Home");
        }


    }
}