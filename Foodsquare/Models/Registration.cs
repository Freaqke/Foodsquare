using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Foodsquare.Models
{
    public class Registration
    {
        [Required(ErrorMessage = "Please enter the Username")]
        public string username { get; set; }

        [Required(ErrorMessage = "Please enter the Password")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Required(ErrorMessage = "Please enter the City")]
        public string city { get; set; }

        [Required(ErrorMessage = "Please enter the Zipcode")]
        public int zipcode { get; set; }

        [Required(ErrorMessage = "Please enter the Phonenumber")]
        [DataType(DataType.PhoneNumber)]
        public int phone { get; set; }

        [Required(ErrorMessage = "Please enter the Email-adress")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        public int online { get; set; }

        public int admin { get; set; }
    }
}