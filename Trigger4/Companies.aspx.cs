using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using Trigger4.App_Code.Models;

namespace Trigger4
{
    public partial class Companies : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                var user = Context.User.Identity;

                if (user.IsAuthenticated)
                {
                    FillPage();
                }
        }

        protected void FillPage()
        {

            var user = Context.User.Identity;

            MyUserModel userModel = new MyUserModel();

            MyUser myUser = new MyUser();

            myUser = userModel.GetUserByName(user.Name);

            litUsername.Text = myUser.UserName;

            int btnNumber = 0;

            if (myUser != null)
            {
                if (myUser.Companies != null)
                {
                    string companies = myUser.Companies;
                    string compList = "";
                    string[] comps = companies.Split(',');
                    foreach (string s in comps)
                    {
                        btnNumber++;
                        compList += "<li>" + "<h2 class=\"comp\">" + s + "</h2>";
                        compList += "<button class=\"btn del\" id=\"" + "button" + btnNumber.ToString() + "\" onclick=\"return false;\">Delete</button>";
                        compList += "</li>";
                    }
                    litComp.Text = compList;
                }
            }
            litStatus.Text = myUser.AccountType.ToString();
            if ((btnNumber >= 8 && myUser.AccountType == 0) || (btnNumber >= 50))
            {
                Button2.Enabled = false;
                txtComp.Enabled = false;
                Button2.Visible = false;
                litStatus.Text = "<p>Maximum Companies Added</p><a href=\"signup.aspx\">Click Here To Upgrade Account</a>";
            }

        }

        private Company CreateCompany()
        {
            Company c = new Company();

            c.Name = txtComp.Text;
            return c;
        }

        protected void UpdateCompanies(MyUser u, string comps)
        {
            MyUserModel userModel = new MyUserModel();

            MyUser myUser = new MyUser();

            myUser.AccountType = u.AccountType;
            myUser.BillingCycle = u.BillingCycle;
            myUser.Email = u.Email;
            myUser.FirstName = u.FirstName;
            myUser.GUI = u.GUI;
            myUser.ID = u.ID;
            myUser.LastLogin = u.LastLogin;
            myUser.LastName = u.LastName;
            myUser.Newsletter = u.Newsletter;
            myUser.Results = u.Results;
            myUser.StartDate = u.StartDate;
            myUser.Triggers = u.Triggers;
            myUser.UserName = u.UserName;

            myUser.Companies = comps;

            userModel.UpdateMyUser(myUser.ID, myUser);
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            var user = Context.User.Identity;

            MyUserModel userModel = new MyUserModel();

            MyUser myUser = new MyUser();

            myUser = userModel.GetUserByName(user.Name);

            CompanyModel compModel = new CompanyModel();

            Company c = CreateCompany();

            if (myUser != null)
            {
                Company test = compModel.GetCompanyByName(txtComp.Text);
                string currentComps = myUser.Companies;
                if (currentComps=="" || currentComps == null)
                {
                    currentComps += txtComp.Text;
                }
                else if (!currentComps.Contains(txtComp.Text))
                {
                    currentComps += "," + txtComp.Text;
                }
                if (test != null)
                {
                    UpdateCompanies(myUser, currentComps);
                    litStatus.Text = txtComp.Text + " was successfully added.";
                }
                else
                {
                    UpdateCompanies(myUser, currentComps);
                    string wasAdded = compModel.InsertCompany(c);
                    litStatus.Text = txtComp.Text + " was successfully added.";
                }
            }            
        }

        protected string GetMyMotherfuckingName()
        {
            var user = Context.User.Identity;

            return user.Name;            
        }

        [WebMethod]
        public static string[] DeleteFromList(string idNum)
        {
            //START HERE
            int id = Convert.ToInt32(idNum);
            //DELETE ID NUM STARTED AT 1
            //SHOW ERROR MESSAGE VIA JS IF FAIL
            Companies c = new Companies();
            string user = c.GetMyMotherfuckingName();

            MyUserModel userModel = new MyUserModel();

            MyUser myUser = new MyUser();

            myUser = userModel.GetUserByName(user);

            string oldComps = myUser.Companies;
            string[] comps = oldComps.Split(',');
            var myList = new List<string>(comps);
            myList.RemoveAt(id-1);
            string[] comps2 = myList.ToArray();
            string newComp = "";
            for (int j = 0; j<comps2.Length; j++)
            {
                if (j == 0) { newComp += comps2[j]; }
                else { newComp += "," + comps2[j]; }
            }
            c.UpdateCompanies(myUser, newComp);

            List<string> retList = new List<string>();
            retList.Add("Was successfull");

            return myList.ToArray();
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home.aspx");
        }

        protected void lnkSignout_Click(object sender, EventArgs e)
        {
            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            authenticationManager.SignOut();
            Response.Redirect("~/TF.aspx");
        }
    }
}