using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Car_with_database.Models;

namespace Car_with_database
{
    /// <summary>
    /// Summary description for Soap
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Soap : System.Web.Services.WebService
    {

        /// <summary>
        /// Soap implemented in asp.net
        /// </summary>
        /// <param name="TripId"></param>
        /// <returns>The name of the driver of a specific trip</returns>
        [WebMethod]
        public string GetDriverNameOfTrip(int TripId)
        {
            CarDatabaseEntities1 db = new CarDatabaseEntities1();

            var result = from m in db.Trip
                where m.TripID == TripId
                select m;
            Trip t = result.First();
            var r = from m in db.User
                where m.UserID == t.UserID
                select m;

            string name = r.First().firstname + " " + r.First().lastName;


            return name;
        }
    }
}
