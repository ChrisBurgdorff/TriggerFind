using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trigger4.App_Code.Models
{
    public class CompanyModel
    {
        public Company GetCompany(int id)
        {
            try
            {
                using (triggerDBEntities db = new triggerDBEntities())
                {
                    Company r = db.Companies.Find(id);
                    return r;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public List<Company> GetAllCompanies()
        {
            try
            {
                using (triggerDBEntities db = new triggerDBEntities())
                {
                    List<Company> rs = (from x in db.Companies
                                       select x).ToList();
                    return rs;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public Company GetCompanyByName(string na)
        {
            triggerDBEntities db = new triggerDBEntities();

            Company comp = (from x in db.Companies
                          where x.Name == na
                          select x).FirstOrDefault();

            return comp;
        }

        public String InsertCompany(Company company)
        {
            try
            {
                triggerDBEntities db = new triggerDBEntities();
                db.Companies.Add(company);
                db.SaveChanges();
                return company.ID.ToString() + " was added successfully.";
            }
            catch (Exception e)
            {
                return "error: " + e;
            }
        }

        public string UpdateCompany(int id, Company company)
        {
            try
            {
                triggerDBEntities db = new triggerDBEntities();
                Company r = db.Companies.Find(id);
                r.AlternateName = company.AlternateName;
                r.CEO = company.CEO;
                r.CFO = company.CFO;
                r.Industry = company.Industry;
                r.Industry2 = company.Industry2;
                r.Name = company.Name;
                r.Symbol = company.Symbol;

                db.SaveChanges();
                return company.ID.ToString() + " was updated succesfully.";
            }
            catch (Exception e)
            {
                return "error: " + e;
            }
        }
        public string DeleteCompany(int id)
        {
            try
            {
                triggerDBEntities db = new triggerDBEntities();
                Tag p = db.Tags.Find(id);
                Company r = db.Companies.Find(id);
                db.Companies.Attach(r);
                db.Companies.Remove(r);
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