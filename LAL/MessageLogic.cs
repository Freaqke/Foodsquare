﻿using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using System.Data;

namespace LAL
{
    public interface IGetMessages
    {
         int id { get; set; }
        string sender { get; set; }
        string receiver { get; set; }
         string text { get; set; }
         DateTime date { get; set; }
         string title { get; set; }

        List<MessageLogic> GetMessageList(string receiver);
    }
    public class MessageLogic : IGetMessages
    {
        public int id { get; set; }
        public string sender { get; set; }
        public string receiver { get; set; }
        public string text { get; set; }
        public DateTime date { get; set; }
        public string title { get; set; }

        public void MessageAdd(int id, string sender, string receiver, string text, DateTime date, string title)
        {
            MessageDb connection = new MessageDb();

            connection.Add(id, sender,receiver, text, date, title);
        }

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
