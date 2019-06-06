using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LAL;
using System.IO;
using Foodsquare.Models;



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

                aLogic.AdvertisementAdd(Session["username"].ToString(), 1, AdvertisementProductTxt);
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

   
            public ActionResult Page(string ids)

        {
            Advertisement aModel = new Advertisement();

            Session["AdverId"] = null;
            
                List<Advertisement> adver = aModel.AdvertisementId(Convert.ToInt32(ids));
                Session["AdverId"] = adver;

         
            return View("Page");
        }

            [HttpPost]
            public ActionResult CommentAdd(string AdvertisementId, string sender, string CommentText)
            {
                foreach (Advertisement item in (List<Advertisement>) Session["AdverId"])

                {
                    AdvertisementId = item.id.ToString();
                }

            if (String.IsNullOrWhiteSpace(CommentText))
                {
                    ViewData["message"] = "Write a comment before submiting";
                }
                else
                {
                    CommentLogic cLogic = new CommentLogic();
                    cLogic.CommentAdd(Convert.ToInt32(AdvertisementId), Session["username"].ToString(),CommentText,DateTime.Now);
                }
                return View("Page");
        }
   }  
}