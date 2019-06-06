using System;
using System.Collections.Generic;
using System.Text;
using DAL;

namespace LAL
{
    public class CommentLogic
    {
        public void CommentAdd(int id, string sender, string text, DateTime date)
        {
            CommentDb connection = new CommentDb();

            connection.Add(id, sender, text, date);
        }
    }
}
