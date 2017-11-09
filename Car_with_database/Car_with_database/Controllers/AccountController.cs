using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;
using Car_with_database.Models;

namespace Car_with_database.Controllers
{
    public class AccountController : Controller
    {

        // GET: Account
        //TODO:make POST
        public ActionResult EditAccountInfo(string newFirstname, string newLastname, string newPassword, string repeatPassword, string newEmail)
        {
            if (string.IsNullOrWhiteSpace(newFirstname)&& string.IsNullOrWhiteSpace(newLastname) && string.IsNullOrWhiteSpace(newPassword) && string.IsNullOrWhiteSpace(newEmail))
            {
                return RedirectToAction("AccountDetails", "Account");
            }
            try
            {
                CarDatabaseEntities1 db = new CarDatabaseEntities1();
                if (!string.IsNullOrWhiteSpace(newFirstname))
                {
                    ((User)Session["user"]).firstname = newFirstname;
                    db.User.AddOrUpdate((User)Session["user"]);
                    db.SaveChanges();
                    return RedirectToAction("AccountDetails", "Account");
                }
                if (!string.IsNullOrWhiteSpace(newLastname))
                {
                    ((User)Session["user"]).firstname = newLastname;
                    db.User.AddOrUpdate((User)Session["user"]);
                    db.SaveChanges();
                    return RedirectToAction("AccountDetails", "Account");
                }
                if (!string.IsNullOrWhiteSpace(newPassword) && newPassword.Equals(repeatPassword))
                {
                    ((User)Session["user"]).password = newPassword;
                    db.User.AddOrUpdate((User)Session["user"]);
                    db.SaveChanges();
                    return RedirectToAction("AccountDetails", "Account");
                }
                if (!string.IsNullOrWhiteSpace(newEmail))
                {
                    ((User)Session["user"]).email = newEmail;
                    db.User.AddOrUpdate((User)Session["user"]);
                    db.SaveChanges();
                    return RedirectToAction("AccountDetails", "Account");
                }
                return View("Error");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return View("Error");
            }
        }

        public ActionResult EditAccount()
        {
            CarDatabaseEntities1 db = new CarDatabaseEntities1();
            List<Trip> usrTrips = new List<Trip>();
            User usr = ((User)Session["user"]);
            var triplistDriver = from m in db.Trip
                where m.UserID == usr.UserID
                select m;
            var triplistPass = from m in db.Trip
                where m.Passengers.Contains(usr.UserID.ToString())
                select m;
            usrTrips = triplistDriver.ToList();
            usrTrips = usrTrips.Concat(triplistPass).ToList();
            ViewBag.trip = usrTrips;
            return View();
        }

        [HttpPost]
        public ActionResult CreateAccount(User user)
        {
            CarDatabaseEntities1 db = new CarDatabaseEntities1();

            User local = user;
            local.isDriver = true;
            db.User.Add(user);
            db.SaveChanges();
            Session["User"] = local;
            return RedirectToAction("AccountDetails");
        }
        public ActionResult CreateAccount()
        {
            return View();
        }
        public ActionResult AccountDetails()
        {
            User use1 = (User) Session["User"];
            return View(use1);
        }
        public ActionResult LoginAccount(string Username, string Password)
        {
            CarDatabaseEntities1 db = new CarDatabaseEntities1();

            User use1 = new User();

            var user = from m in db.User
                where m.userName == Username
                select m;

            use1 = user.First();
            if (use1.password == Password)
            {
                Session["User"] = use1;
                Session["LoggedIn"] = true;
                return RedirectToAction("Index", "Home");
            }
            return Login();
        }
        public ActionResult Login()
        {
            return View("Login");
        }
        [HttpPost]
        public ActionResult LogOff()
        {
            Session["LoggedIn"] = false;
            Session["User"] = null;
            return RedirectToAction("Index", "Home");
        }


    }
}