using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using System.Data;

namespace LAL
{
    public class CommentLogic
    {
        public int id;
        public string sender;
        public string text;
        public DateTime date;

        public void CommentAdd(int id, string sender, string text, DateTime date)
        {
            CommentDb connection = new CommentDb();

            connection.Add(id, sender, text, date);
        }

        public List<CommentLogic> CommentId(int id)
        {
            CommentDb connection = new CommentDb();

            DataTable dataTable = connection.CommentId(id);

            List<CommentLogic> list = new List<CommentLogic>();

            foreach (DataRow dr in dataTable.Rows)
            {
                CommentLogic comment = new CommentLogic();
                comment.id = Convert.ToInt32(dr["Id"]);
                comment.sender = dr["Sender"].ToString();
                comment.text = dr["Text"].ToString();
                comment.date = Convert.ToDateTime(dr["Date"]);
                
                list.Add(comment);
            }
            return list;
        }
    }
}
