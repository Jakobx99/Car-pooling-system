using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Car_with_database.Models;
using Microsoft.Ajax.Utilities;


namespace Car_with_database.Controllers
{
    public class FindTripController : Controller
    {

        // GET: FindTrip
        public ActionResult SearchTrip()
        {
            Session["currentMethod"] = "SearchTrip";
            Session["currentController"] = "FindTrip";
            return View();
        }


        public ActionResult SpecificTrip(Trip t)
        {
            Session["currentMethod"] = "SpecificTrip";
            Session["currentController"] = "FindTrip";
            return View(t);
        }

        [HttpPost]
        public ActionResult SpecificTrip(string id)
        {
            CarDatabaseEntities1 db = new CarDatabaseEntities1();
            Session["currentMethod"] = "SpecificTrip";
            Session["currentController"] = "FindTrip";
            User u = (User)Session["User"];

            int i = Convert.ToInt32(id);
            var result = from m in db.Trip
                         where m.TripID == i
                         select m;
            Trip t = result.First();

            t.numberOfSeats = t.numberOfSeats - 1;

            List<string> passengerList = Listconversion.ConvertToList(t.Passengers);
            passengerList.Add(u.UserID.ToString());
            string passengers = Listconversion.Converttostring(passengerList);
            t.Passengers = passengers;
            
            u.Trip.Add(t);
            db.Trip.AddOrUpdate(t);
            db.User.AddOrUpdate(u);
            db.SaveChanges();

            return RedirectToAction("SpecificTrip", "FindTrip", t);
        }

        
        public ActionResult TripList(string saddress, string szip, string scity, string daddress, string dzip, string dcity, DateTime time)
        {
            List<Trip> tlist = new List<Trip>();
            Session["currentMethod"] = "TripList";
            Session["currentController"] = "FindTrip";

            CarDatabaseEntities1 db = new CarDatabaseEntities1();

            if (!saddress.IsNullOrWhiteSpace())
            {
                var result = from m in db.Trip
                             where m.startingAddress == saddress && m.numberOfSeats > 0
                             select m;
                foreach (var trip in result)
                {
                    if (!tlist.Contains(trip))
                    {
                        tlist.Add(trip);
                    }
                }
            }
            if (!szip.IsNullOrWhiteSpace())
            {
                var result = from m in db.Trip
                             where m.startingZip == szip && m.numberOfSeats > 0
                             select m;
                foreach (var trip in result)
                {
                    if (!tlist.Contains(trip))
                    {
                        tlist.Add(trip);
                    }
                }
            }
            if (!scity.IsNullOrWhiteSpace())
            {
                var result = from m in db.Trip
                             where m.startingCity == scity && m.numberOfSeats > 0
                             select m;
                foreach (var trip in result)
                {
                    if (!tlist.Contains(trip))
                    {
                        tlist.Add(trip);
                    }
                }
            }
            if (!daddress.IsNullOrWhiteSpace())
            {
                var result = from m in db.Trip
                             where m.destinationAddress == daddress && m.numberOfSeats > 0
                             select m;
                foreach (var trip in result)
                {
                    if (!tlist.Contains(trip))
                    {
                        tlist.Add(trip);
                    }
                }
            }
            if (!dzip.IsNullOrWhiteSpace())
            {
                var result = from m in db.Trip
                             where m.destinationZip == dzip && m.numberOfSeats > 0
                             select m;
                foreach (var trip in result)
                {
                    if (!tlist.Contains(trip))
                    {
                        tlist.Add(trip);
                    }
                }
            }
            if (!dcity.IsNullOrWhiteSpace())
            {
                var result = from m in db.Trip
                             where m.destinationCity == dcity && m.numberOfSeats > 0
                             select m;
                foreach (var trip in result)
                {
                    if (!tlist.Contains(trip))
                    {
                        tlist.Add(trip);
                    }
                }
            }

            var date = from m in db.Trip
                       where m.time == time && m.numberOfSeats > 0
                       select m;
            foreach (var trip in date)
            {
                if (!tlist.Contains(trip))
                {
                    tlist.Add(trip);
                }
            }

            return View(tlist);
        }
    }
}