using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using car.Models;

namespace car.Controllers
{
    public class FindTripController : Controller
    {
        // GET: FindTrip
        public ActionResult FindTrip()
        {
            Trip Trip = new Trip();
            Trip.TripID = 1;
            Trip.destinationAddress = "Kennedy";
            Trip.destinationCity = "Aalborg";
            Trip.destinationZip = 9200;
            Trip.driverID = 2;
            Trip.numberOfSeats = 1;
            Trip.passengerID = 0;
            Trip.startingAddress = "Selma";
            Trip.startingCity = "Aalborg";
            Trip.startingZip = 9220;
            Trip.time = DateTime.Now;
            List<Trip> random = new List<Trip>();
            random.Add(Trip);
            return View(random);
        }

        public ActionResult SpecificTrip()
        {
            return View();
        }

        public ActionResult SearchTrip()
        {
            return View();
        }
    }
}