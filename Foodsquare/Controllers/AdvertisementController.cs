using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LAL;
using System.IO;
using Foodsquare.Models;
using Microsoft.Ajax.Utilities;

namespace Foodsquare.Controllers
{
    public class AdvertisementController : Controller
    {
        // GET: Advertisement
        public ActionResult Advertisement()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ProductAdd(string AdvertisementProductName, 
                                       string AdvertisementProductType, 
                                       string AdvertisementProductAmount, 
                                       string AdvertisementProductWeight, 
                                       string AdvertisementProductExpDate, 
                                       HttpPostedFileBase AdvertisementProductImage,  
                                       string AdvertisementProductTxt)
        {
           
            string fileName = AdvertisementProductImage.FileName;
            string fileExtension = Path.GetExtension(fileName);
            int fileSize = AdvertisementProductImage.ContentLength;

            if (fileExtension.ToLower() == ".jpg" ||
                fileExtension.ToLower() == ".bmp" ||
                fileExtension.ToLower() == ".gif" ||
                fileExtension.ToLower() == ".png")
            {
                Stream stream = AdvertisementProductImage.InputStream;
                BinaryReader binaryReader = new BinaryReader(stream);
                byte[] bytes = binaryReader.ReadBytes((int) stream.Length);
           

            if (String.IsNullOrWhiteSpace(AdvertisementProductName) ||
                String.IsNullOrWhiteSpace(AdvertisementProductType) ||
                String.IsNullOrWhiteSpace(AdvertisementProductAmount.ToString()) ||
                String.IsNullOrWhiteSpace(AdvertisementProductWeight) ||
                String.IsNullOrWhiteSpace(AdvertisementProductExpDate.ToString()) ||
                String.IsNullOrWhiteSpace(fileName) ||
                String.IsNullOrWhiteSpace(AdvertisementProductTxt))
            {
                ViewData["message"] = "Product Registration Failed";
            }
            else
            {
                AdvertisementLogic aLogic = new AdvertisementLogic();
                ProductLogic pLogic = new ProductLogic();

                aLogic.AdvertisementAdd(Session.SessionID, 1, AdvertisementProductTxt);
                pLogic.ProductAdd(AdvertisementProductType, Convert.ToInt32(AdvertisementProductAmount), AdvertisementProductWeight, Convert.ToDateTime(AdvertisementProductExpDate), bytes , AdvertisementProductName);

                return RedirectToAction("Index", "Home");
            }
            }
            else
            {
                ViewData["message"] = "Image extension not supported";
            }
            return View("Advertisement");
        }
    }
}