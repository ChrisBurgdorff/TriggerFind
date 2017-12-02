using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trigger4.App_Code.Models
{
    public class ResultModel
    {
        public Result GetResult(int id)
        {
            try
            {
                using (triggerDBEntities db = new triggerDBEntities())
                {
                    Result r = db.Results.Find(id);
                    return r;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public List<Result> GetResultsForUser(string na)
        {
            //na = "4401,4357,4288,4187,4109,4100";
            List<string> resList = na.Split(',').ToList();

            List<Result> myList = new List<Result>();

            triggerDBEntities db = new triggerDBEntities();

            foreach (string s in resList)
            {
                if (s.All(Char.IsDigit) && s != "")
                {
                    int i = Convert.ToInt32(s);
                    Result r = (from x in db.Results
                                where x.ID == i
                                select x).FirstOrDefault();
                    if (r != null)
                    { myList.Add(r); }       
                }     
            }

            return myList;
        }
        public List<Result> GetAllResults()
        {
            try
            {
                using (triggerDBEntities db = new triggerDBEntities())
                {
                    List<Result> rs = (from x in db.Results
                                    select x).ToList();
                    return rs;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public String InsertResult(Result result)
        {
            try
            {
                triggerDBEntities db = new triggerDBEntities();
                db.Results.Add(result);
                db.SaveChanges();
                return result.ID.ToString() + " was added successfully.";
            }
            catch (Exception e)
            {
                return "error: " + e;
            }
        }

        public string UpdateResult(int id, Result result)
        {
            try
            {
                triggerDBEntities db = new triggerDBEntities();
                Result r = db.Results.Find(id);
                r.BodyText = result.BodyText;
                r.Company = result.Company;
                r.DateSearched = result.DateSearched;
                r.Triggers = result.Triggers;

                db.SaveChanges();
                return result.ID.ToString() + " was updated succesfully.";
            }
            catch (Exception e)
            {
                return "error: " + e;
            }
        }
        public string DeleteResult(int id)
        {
            try
            {
                triggerDBEntities db = new triggerDBEntities();
                Tag p = db.Tags.Find(id);
                Result r = db.Results.Find(id);
                db.Results.Attach(r);
                db.Results.Remove(r);
                db.SaveChanges();

                return r.ID.ToString() + " was deleted succesfully.";
            }
            catch (Exception e)
            {
                return "error: " + e;
            }
        }
    }
}