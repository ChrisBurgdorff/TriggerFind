using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trigger4.App_Code.Models
{
    public class MyUserModel
    {
        public MyUser GetMyUser(int id)
        {
            try
            {
                using (triggerDBEntities db = new triggerDBEntities())
                {
                    MyUser m = db.MyUsers.Find(id);
                    return m;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public MyUser GetMyUserByGUI(string GUID)
        {
            triggerDBEntities db = new triggerDBEntities();

            MyUser info = (from x in db.MyUsers
                             where x.GUI == GUID
                             select x).FirstOrDefault();

            return info;
        }
        public MyUser GetUserByName(string na)
        {
            triggerDBEntities db = new triggerDBEntities();

            MyUser use = (from x in db.MyUsers
                          where x.UserName == na
                          select x).FirstOrDefault();

            return use;
        }
        public List<MyUser> GetAllMyUsers()
        {
            try
            {
                using (triggerDBEntities db = new triggerDBEntities())
                {
                    List<MyUser> mu = (from x in db.MyUsers
                                       select x).ToList();
                    return mu;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public String InsertMyUser(MyUser myuser)
        {
            try
            {
                triggerDBEntities db = new triggerDBEntities();
                db.MyUsers.Add(myuser);
                db.SaveChanges();
                return myuser.ID.ToString() + " was added successfully.";
            }
            catch (Exception e)
            {
                return "error: " + e;
            }
        }

        public string UpdateMyUser(int id, MyUser myuser)
        {
            try
            {
                triggerDBEntities db = new triggerDBEntities();
                MyUser mu = db.MyUsers.Find(id);
                mu.AccountType = myuser.AccountType;
                mu.BillingCycle = myuser.BillingCycle;
                mu.Companies = myuser.Companies;
                myuser.Email = myuser.Email;
                mu.FirstName = myuser.FirstName;
                mu.GUI = myuser.GUI;
                mu.LastLogin = myuser.LastLogin;
                mu.LastName = myuser.LastName;
                mu.Newsletter = myuser.Newsletter;
                mu.Results = myuser.Results;
                mu.StartDate = myuser.StartDate;
                mu.Triggers = myuser.Triggers;
                mu.UserName = myuser.UserName;

                db.SaveChanges();
                return myuser.ID.ToString() + " was updated succesfully.";
            }
            catch (Exception e)
            {
                return "error: " + e;
            }
        }
        public string DeleteMyUser(int id)
        {
            try
            {
                triggerDBEntities db = new triggerDBEntities();
                Tag p = db.Tags.Find(id);
                Result r = db.Results.Find(id);
                db.Results.Attach(r);
                db.Results.Remove(r);
                db.SaveChanges();

                MyUser mu = db.MyUsers.Find(id);
                db.MyUsers.Attach(mu);
                db.MyUsers.Remove(mu);
                db.SaveChanges();

                return mu.ID.ToString() + " was deleted succesfully.";
            }
            catch (Exception e)
            {
                return "error: " + e;
            }
        }
    }
}