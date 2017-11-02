using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
            Session["currentMethod"] = "PlanTrip";
            Session["currentController"] = "PlanTrip";
            return View();
        }

        [HttpPost]
        public ActionResult PlanTrip(Trip trip)
        {
            CarDatabaseEntities1 db = new CarDatabaseEntities1();
            Session["currentMethod"] = "PlanTrip";
            Session["currentController"] = "PlanTrip";

            Trip result = trip;
            User u = (User) Session["User"];
            result.UserID = u.UserID;
            u.Trip.Add(result);

            if(ModelState.IsValid)
            { 
            db.Trip.Add(result);
            db.User.AddOrUpdate(u);
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
            Session["currentMethod"] = "SpecificTrip";
            Session["currentController"] = "PlanTrip";
            return View(trip);
        }
    }
}