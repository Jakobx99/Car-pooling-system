using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Car_with_database.Models;


namespace Car_with_database.Controllers
{
    public class FindTripController : Controller
    {
        CarDatabaseEntities1 db = new CarDatabaseEntities1();

        // GET: FindTrip
        public ActionResult SearchTrip()
        {
            return View();
        }

        public ActionResult SpecificTrip(Trip trip)
        {
            return View(trip);
        }

        public ActionResult TripList(Trip trip)
        {
            var result = from m in db.Trip
                where m.destinationAddress == trip.destinationAddress && m.destinationCity == trip.destinationCity
                select m;

            return View(result.ToList());
        }
    }
}