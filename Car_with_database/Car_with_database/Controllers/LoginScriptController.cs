using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Car_with_database.Models;

namespace Car_with_database
{
    public class LoginScriptController : Controller
    {
        // GET: LoginScript
        public ActionResult LoginScript(string usernameLogIn, string passwordLogIn)
        {
            CarDatabaseEntities1 db = new CarDatabaseEntities1();

            User use1 = new User();

            var user = from m in db.User
                where m.userName == usernameLogIn
                       select m;

            use1 = user.First();
            if (use1.password == passwordLogIn)
            {
                Session["User"] = use1;
                Session["LoggedIn"] = true;
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index","Home");
        }
    }
}