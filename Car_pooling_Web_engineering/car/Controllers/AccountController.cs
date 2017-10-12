using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace car.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult CreateAccount()
        {
            return View();
        }

        public ActionResult EditAccount()
        {
            return View();
        }
    }
}