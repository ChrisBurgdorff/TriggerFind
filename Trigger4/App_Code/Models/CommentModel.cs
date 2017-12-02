using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trigger4.AppCode
{
    public class CommentModel
    {
        public String InsertComment(Comment comment)
        {
            try
            {
                triggerDBEntities db = new triggerDBEntities();
                db.Comments.Add(comment);
                db.SaveChanges();
                return " was added succesfully.";
            }
            catch (Exception e)
            {
                return "error: " + e;
            }
        }

        public string UpdateComment(int id, Comment comment)
        {
            try
            {
                triggerDBEntities db = new triggerDBEntities();
                Comment p = db.Comments.Find(id);
                p.Name = comment.Name;
                p.Body = comment.Body;
                p.Email = comment.Email;
                p.DateTime = comment.DateTime;
                p.PostID = comment.PostID;
                

                db.SaveChanges();
                return comment.Name + " was updated succesfully.";
            }
            catch (Exception e)
            {
                return "error: " + e;
            }
        }
        public string UpdateComment(int id)
        {
            try
            {
                triggerDBEntities db = new triggerDBEntities();
                Comment p = db.Comments.Find(id);
                db.Comments.Attach(p);
                db.Comments.Remove(p);
                db.SaveChanges();

                return p.Name + " was deleted succesfully.";
            }
            catch (Exception e)
            {
                return "error: " + e;
            }
        }
        public List<Comment> GetAllComments()
        {
            try
            {
                using (triggerDBEntities db = new triggerDBEntities())
                {
                    List<Comment> cs = (from x in db.Comments
                                        orderby x.DateTime descending
                                        select x).ToList();
                    return cs;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}