﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using LAL;

namespace Foodsquare.Models
{
    public class Advertisement
    {
        public int id { get; set; }
        public string username { get; set; }
        public int available { get; set; }
        public string description { get; set; }
        public string type { get; set; }
        public int amount { get; set; }
        public string weight { get; set; }
        public byte[] image { get; set; }
        public string name { get; set; }
        public List<Advertisement> aList { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy.MM.dd}")]
        public DateTime expiration { get; set; }

        public List<Advertisement> GetAllAdvertisements()
        {
            List<Advertisement> aList = new List<Advertisement>();

            AdvertisementLogic aLogic = new AdvertisementLogic();

            List<AdvertisementLogic> test = aLogic.AdvertisementList();

            foreach (AdvertisementLogic listObj in test)
            {
               Advertisement advertisement = new Advertisement();
               advertisement.id = listObj.id;
               advertisement.username = listObj.username;
               advertisement.available = listObj.available;
                advertisement.description = listObj.description;
                advertisement.type = listObj.type;
                advertisement.amount = listObj.amount;
                advertisement.weight = listObj.weight;
                advertisement.expiration = listObj.expiration;
                advertisement.image = listObj.image;
                advertisement.name = listObj.name;
                aList.Add(advertisement);
            }

            return aList;
        }

        public List<Advertisement> AdvertisementId(int id)
        {
            List<Advertisement> aList = new List<Advertisement>();

            AdvertisementLogic aLogic = new AdvertisementLogic();

            List<AdvertisementLogic> aLogicList = aLogic.AdvertisementId(id);

            foreach (AdvertisementLogic listObj in aLogicList)
            {
                Advertisement advertisement = new Advertisement();
                advertisement.id = listObj.id;
                advertisement.username = listObj.username;
                advertisement.available = listObj.available;
                advertisement.description = listObj.description;
                advertisement.type = listObj.type;
                advertisement.amount = listObj.amount;
                advertisement.weight = listObj.weight;
                advertisement.expiration = listObj.expiration;
                advertisement.image = listObj.image;
                advertisement.name = listObj.name;
                aList.Add(advertisement);
            }

            return aList;
        }
    }
}