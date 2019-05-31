using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Foodsquare.Models
{
    public class Registration
    {
        public string username { get; set; }
        public string password { get; set; }
        public string city { get; set; }
        public string zipcode { get; set; }
        public int phone { get; set; }
        public string email { get; set; }
        public bool online { get; set; }
        public bool admin { get; set; }
    }
}