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
        public ActionResult Login (string loginUsername, string loginPassword)
        {
            Login login = new Login();
            login.username = loginUsername;
            login.password = loginPassword;

            UserLogic user = new UserLogic();

            bool check = user.UserAuthentication(login.username.ToString(),login.password.ToString());

            if (check == true)
            {
                FormsAuthentication.SetAuthCookie(login.username, true);
                Session["username"] = login.username.ToString();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewData["message"] = "Login Details Failed";
            }
            return View();
        }
    }
}