using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using LAL;

namespace Foodsquare.Models
{
    public class Comment
    {
        public int id { get; set; }
        public string sender { get; set; }
        public string text { get; set; }
        [DisplayFormat(ApplyFormatInEditMode =true, DataFormatString = "{0:yyyy.MM.dd}")]
        public DateTime postDate { get; set; }

        public List<Comment> CommentId(int id)
        {
            List<Comment> cList = new List<Comment>();

            CommentLogic cLogic = new CommentLogic();

            List<CommentLogic> cLogicList = cLogic.CommentId(id);

            foreach (CommentLogic listObj in cLogicList)
            {
                Comment comment = new Comment();
                comment.id = listObj.id;
                comment.sender = listObj.sender;
                comment.text = listObj.text;
                comment.postDate = listObj.date;

                cList.Add(comment);
            }

            return cList;
        }
    }
}