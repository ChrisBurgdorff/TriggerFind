using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trigger4.AppCode
{
    public class EmailListModel
    {
        public List<EmailList> GetAllEmailLists()
        {
            try
            {
                using (triggerDBEntities db = new triggerDBEntities())
                {
                    List<EmailList> ts = (from x in db.EmailLists
                                    select x).ToList();
                    return ts;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public String InsertEmailList(EmailList emaillist)
        {
            try
            {
                triggerDBEntities db = new triggerDBEntities();
                db.EmailLists.Add(emaillist);
                db.SaveChanges();
                return emaillist.Name + " was added succesfully.";
            }
            catch (Exception e)
            {
                return "error: " + e;
            }
        }

        public string UpdateEmailList(int id, EmailList emaillist)
        {
            try
            {
                triggerDBEntities db = new triggerDBEntities();
                EmailList p = db.EmailLists.Find(id);
                p.Name = emaillist.Name;

                db.SaveChanges();
                return emaillist.Name + " was updated succesfully.";
            }
            catch (Exception e)
            {
                return "error: " + e;
            }
        }
        public string DeleteEmailList(int id)
        {
            try
            {
                triggerDBEntities db = new triggerDBEntities();
                EmailList p = db.EmailLists.Find(id);
                db.EmailLists.Attach(p);
                db.EmailLists.Remove(p);
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