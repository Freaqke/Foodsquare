using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Foodsquare.Models;

namespace Foodsquare.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Account()
        {
            return View();
        }

        public ActionResult MyAdvertisements()
        {
            return View();
        }

        public ActionResult MyMessages()
        {
            var user = Session["username"].ToString();

            Message aModel = new Message();
            List<Message> aList = aModel.MessageList(user);

            ViewBag.messageList = aList;

            return View();
        }

    }
}