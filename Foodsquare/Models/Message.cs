using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using LAL;

namespace Foodsquare.Models
{
    public class Message
    {
        public int id { get; set; }
        public string sender { get; set; }
        public string receiver { get; set; }
        public string text { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy.MM.dd}")]
        public DateTime postDate { get; set; }
        public string title{ get; set; }

        public List<Message> MessageList (string receiver)
        {
            List<Message> mList = new List<Message>();

            MessageLogic mLogic = new MessageLogic();

            List<MessageLogic> mLogicList = mLogic.GetMessageList(receiver);

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

            return mList;
        }
    }
}