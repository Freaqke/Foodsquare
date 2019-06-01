using System;
using System.Collections.Generic;
using System.Text;
using DAL;

namespace LAL
{
    public class AdvertisementLogic
    {
        public void AdvertisementAdd(string username, int available, string description)
        {
           AdvertisementDb connection = new AdvertisementDb();

           connection.Add(username, available, description);
        }
    }
}
