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
    public partial class Triggers : System.Web.UI.Page
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

            List<string> trigs = new List<string>() ;

            if (myUser != null)
            {
                if (myUser.Triggers != null)
                {
                    string triggers = myUser.Triggers;
                    string trigList = "";
                    trigs = triggers.Split(',').ToList();
                    int btnNumber = 0;
                    foreach (string s in trigs)
                    {
                        btnNumber++;
                        trigList += "<li>" + "<h2 class=\"trig\">" + s + "</h2>";
                        trigList += "<button class=\"btn del\" id=\"" + "button" + btnNumber.ToString() + "\" onclick=\"return false;\">Delete</button>";
                        trigList += "</li>";
                    }
                    litTrig.Text = trigList;
                }
            }
            string[] allTrigs = new string[7] {"Hiring","Merger","Sales","Contracts","Training","Location","CFO"};
            if (trigs.Contains("Hiring"))
            {
                btnHiring.Visible = false;
            }
            if (trigs.Contains("Merger"))
            {
                btnMerger.Visible = false;
            }
            if (trigs.Contains("Sales"))
            {
                btnSales.Visible = false;
            }
            if (trigs.Contains("Contracts"))
            {
                btnContracts.Visible = false;
            }
            if (trigs.Contains("Training"))
            {
                btnTraining.Visible = false;
            }
            if (trigs.Contains("Location"))
            {
                btnLocation.Visible = false;
            }
            if (trigs.Contains("CFO"))
            {
                btnCFO.Visible = false;
            }
            if (myUser != null)
            {
                if (myUser.Triggers != null)
                {
                    string triggers = myUser.Triggers;
                    string trigList = "";
                    trigs = triggers.Split(',').ToList();
                    int btnNumber = 0;
                    foreach (string s in trigs)
                    {
                        btnNumber++;
                        trigList += "<li>" + "<h2 class=\"trig\">" + s + "</h2>";
                        trigList += "<button class=\"btn del\" id=\"" + "button" + btnNumber.ToString() + "\" onclick=\"return false;\">Delete</button>";
                        trigList += "</li>";
                    }
                    litTrig.Text = trigList;
                }
            }
        }

        protected void UpdateTriggers(MyUser u, string trigs)
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
            myUser.Companies = u.Companies;
            myUser.UserName = u.UserName;

            myUser.Triggers = trigs;

            userModel.UpdateMyUser(myUser.ID, myUser);
        }

        protected void btnHiring_Click(object sender, EventArgs e)
        {
            btnHiring.Enabled = false;
            btnHiring.Visible = false;  
            var user = Context.User.Identity;

            MyUserModel userModel = new MyUserModel();

            MyUser myUser = new MyUser();

            myUser = userModel.GetUserByName(user.Name);

            string myTriggers = myUser.Triggers;

            if (myTriggers == "" || myTriggers == null)
            {
                myTriggers = "Hiring";
            }
            else if(!myTriggers.Contains("Hiring"))
            {
                myTriggers += ",Hiring";
            }
            UpdateTriggers(myUser, myTriggers);
        }

        protected void btnMerger_Click(object sender, EventArgs e)
        {
            btnMerger.Enabled = false;
            btnMerger.Visible = false;
            var user = Context.User.Identity;

            MyUserModel userModel = new MyUserModel();

            MyUser myUser = new MyUser();

            myUser = userModel.GetUserByName(user.Name);

            string myTriggers = myUser.Triggers;

            if (myTriggers == "" || myTriggers == null)
            {
                myTriggers = "Merger";
            }
            else if (!myTriggers.Contains("Merger"))
            {
                myTriggers += ",Merger";
            }
            UpdateTriggers(myUser, myTriggers);
        }

        protected void btnSales_Click(object sender, EventArgs e)
        {
            btnSales.Enabled = false;
            btnSales.Visible = false;
            var user = Context.User.Identity;

            MyUserModel userModel = new MyUserModel();

            MyUser myUser = new MyUser();

            myUser = userModel.GetUserByName(user.Name);

            string myTriggers = myUser.Triggers;

            if (myTriggers == "" || myTriggers == null)
            {
                myTriggers = "Sales";
            }
            else if (!myTriggers.Contains("Sales"))
            {
                myTriggers += ",Sales";
            }
            UpdateTriggers(myUser, myTriggers);
        }

        protected void btnContracts_Click(object sender, EventArgs e)
        {
            btnContracts.Enabled = false;
            btnContracts.Visible = false;
            var user = Context.User.Identity;

            MyUserModel userModel = new MyUserModel();

            MyUser myUser = new MyUser();

            myUser = userModel.GetUserByName(user.Name);

            string myTriggers = myUser.Triggers;

            if (myTriggers == "" || myTriggers == null)
            {
                myTriggers = "Contracts";
            }
            else if (!myTriggers.Contains("Contracts"))
            {
                myTriggers += ",Contracts";
            }
            UpdateTriggers(myUser, myTriggers);
        }

        protected void btnTraining_Click(object sender, EventArgs e)
        {
            btnTraining.Enabled = false;
            btnTraining.Visible = false;
            var user = Context.User.Identity;

            MyUserModel userModel = new MyUserModel();

            MyUser myUser = new MyUser();

            myUser = userModel.GetUserByName(user.Name);

            string myTriggers = myUser.Triggers;

            if (myTriggers == "" || myTriggers == null)
            {
                myTriggers = "Training";
            }
            else if (!myTriggers.Contains("Training"))
            {
                myTriggers += ",Training";
            }
            UpdateTriggers(myUser, myTriggers);
        }

        protected void btnLocation_Click(object sender, EventArgs e)
        {
            btnLocation.Enabled = false;
            btnLocation.Visible = false;
            var user = Context.User.Identity;

            MyUserModel userModel = new MyUserModel();

            MyUser myUser = new MyUser();

            myUser = userModel.GetUserByName(user.Name);

            string myTriggers = myUser.Triggers;

            if (myTriggers == "" || myTriggers == null)
            {
                myTriggers = "Location";
            }
            else if (!myTriggers.Contains("Location"))
            {
                myTriggers += ",Location";
            }
            UpdateTriggers(myUser, myTriggers);
        }

        protected void btnCFO_Click(object sender, EventArgs e)
        {
            btnCFO.Enabled = false;
            btnCFO.Visible = false;
            var user = Context.User.Identity;

            MyUserModel userModel = new MyUserModel();

            MyUser myUser = new MyUser();

            myUser = userModel.GetUserByName(user.Name);

            string myTriggers = myUser.Triggers;

            if (myTriggers == "" || myTriggers == null)
            {
                myTriggers = "CFO";
            }
            else if (!myTriggers.Contains("CFO"))
            {
                myTriggers += ",CFO";
            }
            UpdateTriggers(myUser, myTriggers);
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
            Triggers t = new Triggers();
            string user = t.GetMyMotherfuckingName();

            MyUserModel userModel = new MyUserModel();

            MyUser myUser = new MyUser();

            myUser = userModel.GetUserByName(user);

            string oldComps = myUser.Triggers;
            string[] comps = oldComps.Split(',');
            var myList = new List<string>(comps);
            myList.RemoveAt(id - 1);
            string[] comps2 = myList.ToArray();
            string newComp = "";
            for (int j = 0; j < comps2.Length; j++)
            {
                if (j == 0) { newComp += comps2[j]; }
                else { newComp += "," + comps2[j]; }
            }
            t.UpdateTriggers(myUser, newComp);

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