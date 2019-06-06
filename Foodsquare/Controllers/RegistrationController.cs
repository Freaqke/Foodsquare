using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Foodsquare.Models;
using LAL;

namespace Foodsquare.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        public ActionResult Registration()
        {
            if (Session["username"] != null)
            {
                User uModel = new User();
                List<User> uList = uModel.UserList(Session["username"].ToString());
                ViewBag.userList = uList;
            }
            return View();
        }

        [HttpPost]
        public ActionResult Register (string registrationUsername, string registrationPassword, string registrationCity, string registrationZipcode, string registrationPhone, string registrationEmail)
        {
            if (String.IsNullOrWhiteSpace(registrationUsername) || 
                String.IsNullOrWhiteSpace(registrationPassword) ||
                String.IsNullOrWhiteSpace(registrationCity) ||
                String.IsNullOrWhiteSpace(registrationZipcode.ToString()) ||
                String.IsNullOrWhiteSpace(registrationPhone.ToString()) ||
                String.IsNullOrWhiteSpace(registrationUsername) ||
                String.IsNullOrWhiteSpace(registrationEmail))
            {
                ViewData["message"] = "Registration Details Failed";
            }
            else
            {
                UserLogic user = new UserLogic();
                user.UserRegistration(registrationUsername, registrationPassword, registrationCity, registrationZipcode, registrationPhone, registrationEmail, 0, 0);
                return RedirectToAction("Login", "Login");
            }
            return View("Registration");
        }
    }
}