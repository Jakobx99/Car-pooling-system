using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages;

namespace Car_with_database.Models
{
    public static class Listconversion
    {
        public static string Converttostring(List<string> list)
        {
            string returned = String.Empty;
            foreach (var person in list)
            {

                returned += person + ",";
            }
            return returned;
        }

        public static List<string> ConvertToList(string input)
        {
            List<string> returnList = new List<string>();
            char[] delimiters = new char[] { ',' };
            if (!string.IsNullOrEmpty(input))
            {
                string[] split = input.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
                foreach (var person in split)
                {
                    returnList.Add(person);
                }
            }
            return returnList;
        }

    }
}