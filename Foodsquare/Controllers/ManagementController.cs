using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Foodsquare.Models;

namespace Foodsquare.Controllers
{
    public class ManagementController : Controller
    {
        // GET: Management
        public ActionResult Management()
        {
            Advertisement aModel = new Advertisement();
            List<Advertisement> advertisements = aModel.GetAllAdvertisements();

            ViewBag.ListAdvertisements = advertisements;

            return View();
        }
    }
}