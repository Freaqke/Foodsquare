using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Foodsquare.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Please enter the Username")]
        public string username { get; set; }

        [Required(ErrorMessage = "Please enter the Password")]
        [Display(Name = "Enter Password")]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}