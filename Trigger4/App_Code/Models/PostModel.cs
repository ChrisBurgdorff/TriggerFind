using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trigger4.AppCode
{
    public class PostModel
    {
        public Post GetPost(int id)
        {
            try
            {
                using (triggerDBEntities db = new triggerDBEntities())
                {
                    Post p = db.Posts.Find(id);
                    return p;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<Post> GetPostsByTag()
        {
            try
            {
                using (triggerDBEntities db = new triggerDBEntities())
                {
                    List<Post> ps = (from x in db.Posts
                                     orderby x.DateTime descending
                                     select x).ToList();
                    return ps;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<Post> GetAllPosts()
        {
            try
            {
                List<Post> ps;
                triggerDBEntities db = new triggerDBEntities();
                using (db )
                {
                    ps = (from x in db.Posts
                                     orderby x.DateTime descending
                                     select x).ToList();
                }
                return ps;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        
        public String InsertPost(Post post)
        {
            try
            {
                triggerDBEntities db = new triggerDBEntities();
                db.Posts.Add(post);
                db.SaveChanges();
                return post.Title + " was added succesfully.";
            }
            catch (Exception e)
            {
                return "error: " + e;
            }
        }

        public string UpdatePost(int id, Post post)
        {
            try
            {
                triggerDBEntities db = new triggerDBEntities();
                Post p = db.Posts.Find(id);
                p.Title = post.Title;
                p.DateTime = post.DateTime;
                p.Body = post.Body;
                p.Comments = post.Comments;
                //p.Tags = post.Tags;
                p.Tags1 = post.Tags1;
                p.IsDraft = post.IsDraft;

                db.SaveChanges();
                return post.Title + " was updated succesfully.";
            }
            catch (Exception e)
            {
                return "error: " + e;
            }
        }
        public string DeletePost(int id)
        {
            try
            {
                triggerDBEntities db = new triggerDBEntities();
                Post p = db.Posts.Find(id);
                db.Posts.Attach(p);
                db.Posts.Remove(p);
                db.SaveChanges();

                return p.Title + " was deleted succesfully.";
            }
            catch (Exception e)
            {
                return "error: " + e;
            }
        }
    }
}