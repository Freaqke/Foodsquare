﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Foodsquare.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        public ActionResult Message()
        {
            return View();
        }
    }
}