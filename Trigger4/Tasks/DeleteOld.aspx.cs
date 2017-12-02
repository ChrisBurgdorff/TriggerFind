using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Trigger4.App_Code.Models;

namespace Trigger4.Tasks
{
    public partial class DeleteOld : System.Web.UI.Page
    {
        protected void DeleteFromUsers(string resultString)
        {
            string[] results = resultString.Split(',');
            List<MyUser> allUsers = new List<MyUser>();
            MyUserModel mu = new MyUserModel();
            allUsers = mu.GetAllMyUsers();
            foreach (MyUser u in allUsers)
            {
                string newResults = "";
                bool found = false;
                if (u.Results != null)
                {
                    string oldResults = u.Results;
                    string[] oldResultsArray = oldResults.Split(',');
                    for (int i = 0; i < oldResultsArray.Length; i++)
                    {
                        found = false;
                        for (int j = 0; j < results.Length; j++)
                        {
                            if (results[j] == oldResultsArray[i])
                            {
                                found = true;
                            }
                        }
                        if (!found)
                        {
                            if (newResults.Length > 2)
                            {
                                newResults = newResults +  "," + oldResultsArray[i];
                            }
                            else
                            {
                                newResults = newResults + oldResultsArray[i];
                            }
                        }
                    }
                    MyUser newUse = new MyUser();
                    newUse.AccountType = u.AccountType;
                    newUse.BillingCycle = u.BillingCycle;
                    newUse.Companies = u.Companies;
                    newUse.Email = u.Email;
                    newUse.FirstName = u.FirstName;
                    newUse.GUI = u.GUI;
                    newUse.ID = u.ID;
                    newUse.LastLogin = u.LastLogin;
                    newUse.LastName = u.LastName;
                    newUse.Newsletter = u.Newsletter;
                    newUse.Results = newResults;
                    newUse.StartDate = u.StartDate;
                    newUse.Triggers = u.Triggers;
                    newUse.UserName = u.UserName;
                    mu.UpdateMyUser(u.ID, newUse);
                }
            }
        }
        
        protected void DeleteOldResults()
        {
            List<Result> allResults = new List<Result>();
            ResultModel m = new ResultModel();
            allResults = m.GetAllResults();
            string status = "";
            string resString = "";
            DateTime deleteDate = DateTime.Now.AddDays(-7);
            foreach (Result r in allResults)
            {
                if (r.DateSearched < deleteDate)
                {
                    status = m.DeleteResult(r.ID);
                    resString = resString + r.ID.ToString() + ",";
                }
                else if (r.Triggers == "" || r.Triggers == null)
                {
                    status = m.DeleteResult(r.ID);
                    resString = resString + r.ID.ToString() + ",";
                }
            }
            DeleteFromUsers(resString);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            DeleteOldResults();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}