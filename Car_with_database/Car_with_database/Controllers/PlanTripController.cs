using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Car_with_database.Models;

namespace Car_with_database.Controllers
{
    public class PlanTripController : Controller
    {
        CarDatabaseEntities1 db = new CarDatabaseEntities1();
        // GET: PlanTrip
        public ActionResult PlanTrip()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PlanTrip(Trip trip)
        {

            Trip result = trip;
            result.driverID = 1;
            if(ModelState.IsValid)
            { 
            db.Trip.Add(result);
            db.SaveChanges();
            return RedirectToAction("SpecificTrip", "FindTrip", result);
            }
            else
            {
                return View("PlanTrip");
            }
        }
    }
}