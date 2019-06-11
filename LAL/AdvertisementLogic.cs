using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using DAL;


namespace LAL
{
    public class AdvertisementLogic 
    {
        public int id;
        public string username;
        public int available;
        public string description;
        public string type;
        public int amount;
        public string weight;
        public DateTime expiration;
        public byte[] image;
        public string name;



        public void AdvertisementAdd(string username, int available, string description)
        {
           AdvertisementDb connection = new AdvertisementDb();

           connection.Add(username, available, description);
        }

        public List<AdvertisementLogic> AdvertisementList()
        {
            AdvertisementDb connection = new AdvertisementDb();

            DataTable dataTable = connection.AdvertisementInformation();

            List<AdvertisementLogic> list = new List<AdvertisementLogic>();

            foreach (DataRow dr in dataTable.Rows)
            {
                AdvertisementLogic advertisement = new AdvertisementLogic();
                advertisement.id = Convert.ToInt32(dr["Id"]);
                advertisement.username = dr["Username"].ToString();
                advertisement.available = Convert.ToInt32(dr["Available"]);
                advertisement.description = dr["Description"].ToString();
                advertisement.type = dr["Type"].ToString();
                advertisement.amount = Convert.ToInt32(dr["Amount"]);
                advertisement.weight = dr["Weight"].ToString();
                advertisement.expiration = Convert.ToDateTime(dr["Expiration"]);
                advertisement.image = (byte[])(dr["Image"]);
                advertisement.name = dr["Name"].ToString();
                list.Add(advertisement);
            }
            return list;
        }
        public List<AdvertisementLogic> AdvertisementId(int id)
        {
            AdvertisementDb connection = new AdvertisementDb();

            DataTable dataTable = connection.AdvertisementId(id);

            List<AdvertisementLogic> list = new List<AdvertisementLogic>();

            foreach (DataRow dr in dataTable.Rows)
            {
                AdvertisementLogic advertisement = new AdvertisementLogic();
                advertisement.id = Convert.ToInt32(dr["Id"]);
                advertisement.username = dr["Username"].ToString();
                advertisement.available = Convert.ToInt32(dr["Available"]);
                advertisement.description = dr["Description"].ToString();
                advertisement.type = dr["Type"].ToString();
                advertisement.amount = Convert.ToInt32(dr["Amount"]);
                advertisement.weight = dr["Weight"].ToString();
                advertisement.expiration = Convert.ToDateTime(dr["Expiration"]);
                advertisement.image = (byte[])(dr["Image"]);
                advertisement.name = dr["Name"].ToString();
                list.Add(advertisement);
            }
            return list;
        }
    }
}
