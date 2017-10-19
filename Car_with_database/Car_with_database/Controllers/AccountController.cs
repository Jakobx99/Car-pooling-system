using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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

        public ActionResult CreateAccount()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }


    }
}