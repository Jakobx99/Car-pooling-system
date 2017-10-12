using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace car.Models
{
    public class Trip
    {
        public int TripID { get; set; }
        public string startingAddress { get; set; }
        public int startingZip { get; set; }
        public string startingCity { get; set; }
        public string destinationAddress { get; set; }
        public int destinationZip { get; set; }
        public string destinationCity { get; set; }
        public DateTime time { get; set; }
        public int driverID { get; set; }
        public int numberOfSeats { get; set; }
        public int passengerID { get; set; }
    }
}