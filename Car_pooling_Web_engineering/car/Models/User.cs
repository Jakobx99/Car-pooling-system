using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace car.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string firstName { get; set; }
        public string LastName { get; set; }
        public string address { get; set; }
        public bool isDriver { get; set; }
        public string phoneNumber { get; set; }
        public string LanguageISOCode { get; set; }
        public string CountryISOCode { get; set; }
        public double Rating { get; set; }
    }
}