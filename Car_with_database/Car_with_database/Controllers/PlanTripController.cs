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
        // GET: PlanTrip
        public ActionResult PlanTrip()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PlanTrip(Trip trip)
        {
            CarDatabaseEntities1 db = new CarDatabaseEntities1();

            Trip result = trip;
            result.driverID = 1;
            if(ModelState.IsValid)
            { 
            db.Trip.Add(result);
            db.SaveChanges();
            return RedirectToAction("SpecificTrip", result);
            }
            else
            {
                return View("PlanTrip");
            }
        }

        public ActionResult SpecificTrip(Trip trip)
        {
            return View(trip);
        }
    }
}