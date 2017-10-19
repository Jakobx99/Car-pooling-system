using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Car_with_database.Controllers
{
    public class PlanTripController : Controller
    {
        // GET: PlanTrip
        public ActionResult PlanTrip()
        {
            return View();
        }
    }
}