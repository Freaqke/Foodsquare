using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using System.Data;

namespace LAL
{
    public class MessageLogic
    {
        public int id;
        public string sender;
        public string receiver;
        public string text;
        public DateTime date;
        public string title;

        public void MessageAdd(int id, string sender, string receiver, string text, DateTime date, string title)
        {
            MessageDb connection = new MessageDb();

            connection.Add(id, sender,receiver, text, date, title);
        }
    }
}
