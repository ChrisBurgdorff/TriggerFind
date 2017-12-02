using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Trigger4.App_Code.Models;

namespace Trigger4.Tasks
{
    public partial class FixCommas : System.Web.UI.Page
    {
        protected void FixMotherfuckingCommas()
        {
            //string[] results = resultString.Split(',');
            List<MyUser> allUsers = new List<MyUser>();
            MyUserModel mu = new MyUserModel();
            allUsers = mu.GetAllMyUsers();
            foreach (MyUser u in allUsers)
            {
                string newResults = "";
                bool found = false;
                List<string> newres = new List<string>();
                string newResString = "";
                if (u.Results != null)
                {
                    string oldResults = u.Results;
                    int len = oldResults.Length;
                    string[] oldresarray = oldResults.Split(',');
                    if (len > 3)
                    {
                        for (int j = 0; j < oldresarray.Length; j++)
                        {
                            if (Convert.ToInt32(oldresarray[j]) > 4356)
                            {
                                //newres.Add(oldResults.Substring(j * 4, 4));
                                if (newResString.Length > 2)
                                {
                                    newResString = newResString + "," + oldresarray[j];
                                }
                                else
                                {
                                    newResString = newResString + oldresarray[j];
                                }
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
                    newUse.Results = newResString;
                    newUse.StartDate = u.StartDate;
                    newUse.Triggers = u.Triggers;
                    newUse.UserName = u.UserName;
                    mu.UpdateMyUser(u.ID, newUse);
                }
            }
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            FixMotherfuckingCommas();
        }
    }
}