using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Foodsquare.Models;
using LAL;

namespace Foodsquare.Controllers
{
    public class HomeController : Controller
    {
  
        public ActionResult Index()
        {

            Advertisement aModel = new Advertisement();
            List<Advertisement> advertisements = aModel.GetAllAdvertisements();

            ViewBag.ListAdvertisements = advertisements;

            return View();         
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}