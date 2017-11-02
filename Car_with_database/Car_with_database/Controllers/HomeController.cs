using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Car_with_database.Models;


namespace Car_with_database.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Session["currentMethod"] = "Index";
            Session["currentController"] = "Home";

            if (Session["User"] == null)
            {
                Session["LoggedIn"] = false;
            }


 


            return View();
        }
    }
}