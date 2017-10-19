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
        CarDatabaseEntities1 db = new CarDatabaseEntities1();

        // GET: Account
        public ActionResult EditAccount()
        {
            User use = new User();

            var user = from m in db.User
                where m.UserID == 1
                select m;

            use = user.First();

            return View(use);
        }

        [HttpPost]
        public ActionResult CreateAccount(User user)
        {
            User local = user;
            local.isDriver = true;
            db.User.Add(user);
            db.SaveChanges();
            Session.Add("User",local.UserID);
            return RedirectToAction("AccountDetails");
        }
        public ActionResult CreateAccount()
        {
            return View();
        }
        public ActionResult AccountDetails()
        {
            User use1 = new User();
            try
            {
                string userID = Session["User"].ToString();
                int actual = int.Parse(userID);

                var user = from m in db.User
                           where m.UserID == actual
                           select m;
                use1 = user.First();
            }
            catch (Exception e)
            {
                //FAK SOME SQL ERROR HAPPENEND
            }
            return View(use1);
        }
        public ActionResult LoginAccount(string Username, string Password)
        {
            User use1 = new User();

            var user = from m in db.User
                where m.userName == Username
                select m;

            use1 = user.First();
            if (use1.password == Password)
            {
                Session["Username"] = use1.userName;
                Session["User"] = use1.UserID;
                return View("~/Views/Home/Index.cshtml");
            }
            return Login();
        }
        public ActionResult Login()
        {
            return View("~/Views/Account/Login.cshtml");
        }


    }
}