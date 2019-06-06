using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Foodsquare.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;
using System.Web.Security;
using LAL;

namespace Foodsquare.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(string loginUsername, string loginPassword)
        {
            UserLogic user = new UserLogic();

            bool check = user.UserAuthentication(loginUsername, loginPassword);

            if (check == true)
            {
                FormsAuthentication.SetAuthCookie(loginUsername, true);
                Session["username"] = loginUsername;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewData["message"] = "Login Details Failed";
            }
            return View();
        }

        [HttpPost]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}