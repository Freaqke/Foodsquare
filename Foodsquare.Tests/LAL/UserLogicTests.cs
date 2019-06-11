using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LAL;
using DAL;
using System.Data;


namespace Foodsquare.Tests.LAL
{
    [TestClass]
    public class UserLogicTests
    {
        [TestMethod]
        public void LoginConfirmed()
        {
            ILogin login = new FakeUserLogic();

            bool check = login.UserAuthentication("Admin", "Admin123");

            Assert.IsNotNull(check);
            Assert.IsTrue(check);
            
        }

        [TestMethod]
        public void LoginUnconfirmed()
        {
            ILogin login = new FakeUserLogic();

            bool check = login.UserAuthentication("Admin", "Admin13");

            Assert.IsNotNull(check);
            Assert.IsFalse(check);

        }

        [TestMethod]
        public void AdminConfirmed()
        {
            IAdminVerification Admin = new FakeUserLogic();

            List<UserLogic> uList = Admin.AdminVerification("Admin");


            foreach (UserLogic user in uList)
            {
                int isAdmin = user.admin;
                Assert.AreEqual(1, isAdmin);
            }
         
        }
        [TestMethod]
        public void AdminUnconfirmed()
        {
            IAdminVerification Admin = new FakeUserLogic();

            List<UserLogic> uList = Admin.AdminVerification("User");


            foreach (UserLogic user in uList)
            {
                int isAdmin = user.admin;
                Assert.AreEqual(0, isAdmin);
            }

        }
    }


    public class FakeUserLogic : ILogin, IAdminVerification
    {
        public string username { get; set; }
        public string password { get; set; }
        [TestMethod]
        public bool UserAuthentication(string username, string password)
        {
            UserDb connection = new UserDb();

            if (connection.LoginCredentials(username, password).Read())
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public List<UserLogic> AdminVerification(string username)
        {
            UserDb connection = new UserDb();
            DataTable dataTable = connection.UserCredentials(username);
            List<UserLogic> list = new List<UserLogic>();

            foreach (DataRow dr in dataTable.Rows)
            {
                UserLogic user = new UserLogic();
                user.admin = Convert.ToInt32(dr["Admin"]);
                list.Add(user);
            }

            return list;
        }
    }
}
