using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LAL;
using DAL;
using System.Data;
using Foodsquare.Models;

namespace Foodsquare.Tests.LAL
{
    [TestClass]
    public class MessageLogicTests
    {
        [TestMethod]
        public void MessagesConfirmed()
        {
            List<Message> mList = new List<Message>();

            IGetMessages mLogic = new FakeMessageLogic();

            List<MessageLogic> mLogicList = mLogic.GetMessageList("Admin");

            foreach (MessageLogic listObj in mLogicList)
            {
                Message message = new Message();
                message.id = listObj.id;
                message.sender = listObj.sender;
                message.receiver = listObj.receiver;
                message.text = listObj.text;
                message.postDate = listObj.date;
                message.title = listObj.title;

                mList.Add(message);
            }
            Assert.IsNotNull(mList);
        }
    }

    public class FakeMessageLogic : IGetMessages
    {
        public int id { get; set; }
        public string sender { get; set; }
        public string receiver { get; set; }
        public string text { get; set; }
        public DateTime date { get; set; }
        public string title { get; set; }

        [TestMethod]
        public List<MessageLogic> GetMessageList(string receiver)
        {
            MessageDb connection = new MessageDb();

            DataTable dataTable = connection.GetMessages(receiver);

            List<MessageLogic> list = new List<MessageLogic>();

            foreach (DataRow dr in dataTable.Rows)
            {
                MessageLogic message = new MessageLogic();
                message.id = Convert.ToInt32(dr["Id"]);
                message.sender = dr["Sender"].ToString();
                message.receiver = dr["Receiver"].ToString();
                message.text = dr["Text"].ToString();
                message.date = Convert.ToDateTime(dr["Date"]);
                message.title = dr["Title"].ToString();

                list.Add(message);
            }

            return list;
        }
    }
}
