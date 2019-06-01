using System;
using System.Collections.Generic;
using System.Text;
using DAL;

namespace LAL
{
    public class ProductLogic
    {
        public void ProductAdd(string type, int amount, string weight, DateTime expiration, byte[] image, string name)
        {
            ProductDb connection = new ProductDb();

            connection.Add(type, amount, weight, expiration, image, name);
        }
    }
}
