using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Foodsquare.Models;
using LAL;

namespace Foodsquare.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        public ActionResult Message()
        {

            return View();
        }

        [HttpPost]
        public ActionResult MessageAdd(string messageid, string sender, string receiver, string messageText, string messageTitle)
        {
            foreach (Advertisement item in (List<Advertisement>)Session["AdverId"])
            {
                messageid = item.id.ToString();
                receiver = item.username;
            }
            if (String.IsNullOrWhiteSpace(messageText))
            {
                ViewData["message"] = "Write a message before submiting";
            }
            else
            {
                MessageLogic mLogic = new MessageLogic();
                mLogic.MessageAdd(Convert.ToInt32(messageid), Session["username"].ToString(), receiver, messageText, DateTime.Now, messageTitle);

                ViewData["message"] = "Message has been sent";
            }
            return View("Message");
        }

    }
}