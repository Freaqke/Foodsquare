using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Foodsquare.Models;
using LAL;

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

            Message mModel = new Message();
            List<Message> mList = mModel.MessageList(user);

            ViewBag.messageList = mList;

            return View();
        }
        [HttpPost]
        public ActionResult ReturnMessage(string receiver)

        {
            Advertisement aModel = new Advertisement();
            aModel.username = receiver;
            aModel.id = 0;
            Session["AdverId"] = null;

            List<Advertisement> adver = new List<Advertisement>();

            adver.Add(aModel);


            Session["AdverId"] = adver;

            return RedirectToAction("Message", "Message");

        }
    }
}