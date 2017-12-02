using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trigger4.AppCode
{
    public class TagModel
    {
        public List<Tag> GetAllTags()
        {
            try
            {
                using (triggerDBEntities db = new triggerDBEntities())
                {
                    List<Tag> ts = (from x in db.Tags
                                     select x).ToList();
                    return ts;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
        
        public String InsertTag(Tag tag)
        {
            try
            {
                triggerDBEntities db = new triggerDBEntities();
                db.Tags.Add(tag);
                db.SaveChanges();
                return tag.Name + " was added succesfully.";
            }
            catch (Exception e)
            {
                return "error: " + e;
            }
        }

        public string UpdateTag(int id, Tag tag)
        {
            try
            {
                triggerDBEntities db = new triggerDBEntities();
                Tag p = db.Tags.Find(id);
                p.Name = tag.Name;

                db.SaveChanges();
                return tag.Name + " was updated succesfully.";
            }
            catch (Exception e)
            {
                return "error: " + e;
            }
        }
        public string DeleteTag(int id)
        {
            try
            {
                triggerDBEntities db = new triggerDBEntities();
                Tag p = db.Tags.Find(id);
                db.Tags.Attach(p);
                db.Tags.Remove(p);
                db.SaveChanges();

                return p.Name + " was deleted succesfully.";
            }
            catch (Exception e)
            {
                return "error: " + e;
            }
        }
    }
}