using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Trigger4.App_Code.Models;

namespace Trigger4
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var user = Context.User.Identity;

                if (user.IsAuthenticated)
                {
                    FillPage();
                }
            }
        }
        protected void FillPage()
        {
            litNewAlerts.Text = "0 new results.";
            //ADD LOGIC TO GET NUMBER OF ALERTS
            
            bool hasAlerts = false;

            var user = Context.User.Identity;
            
            MyUserModel userModel = new MyUserModel();
            
            MyUser myUser = new MyUser();

            myUser = userModel.GetUserByName(user.Name);

            //litUsername.Text = myUser.UserName;

            myUser.LastLogin = DateTime.Now;
            
            if (myUser != null)
            {
                //litNewAlerts.Text = myUser.Triggers + "HELLO";
                if ((myUser.FirstName == null) || (myUser.FirstName == ""))
                {
                    litFName.Text = myUser.UserName;
                }
                else
                {
                    litFName.Text = myUser.FirstName;
                }
                if ((myUser.Results == null) || (myUser.Results == ""))
                {
                        if ((myUser.Companies == null) || (myUser.Companies == ""))
                        {
                            if ((myUser.Triggers == null) || (myUser.Triggers == ""))
                            {
                                litMain.Text = "<h3>Welcome to Trigger Find.</h3><h3>Let's get started by adding some companies to follow.</h3><h3>Select the \"Companies\" tab on the left.</h3>";
                            }
                            else
                            {
                                litMain.Text = "<h3>Now that you have added some companies, let's add some Triggers to follow.</h3><h3>Select the \"Triggers\" tab.</h3>";
                            }
                        }
                        else
                        {
                            if (myUser.StartDate.Value.Date == DateTime.Now.Date)
                            {
                                litMain.Text = "<h3>Now that your account is set up, check back daily to see any new alerts from your Triggers.</h3>";
                            }
                        }
                }
                if (myUser.Results != null)
                {
                    string userRes = myUser.Results;
                    //userRes = myUser.Results;
                    ResultModel resModel = new ResultModel();
                    List<Trigger4.Result> myResults = new List<Trigger4.Result>();
                    myResults = resModel.GetResultsForUser(userRes);
                    string userTest = "Count: " + myResults.Count.ToString() + ". String: " + userRes;
                    
                    DateTime last = myUser.LastLogin.Value.AddDays(-1);
                    List<int> toDel = new List<int>();
                    foreach (Result re in myResults)
                    {
                        if (last.Date < re.DateSearched.Value.Date)
                        {
                            toDel.Add(re.ID);
                        }
                    }
                    foreach (int id in toDel)
                    {
                        Result del = resModel.GetResult(id);
                        myResults.Remove(del);
                    }
                    List<Result> sortedList = myResults.OrderByDescending(o=>o.DateSearched).ToList();
                    if (myResults.Count == 1)
                        {
                            litNewAlerts.Text = myResults.Count.ToString() + " New Alert.";
                        }
                        else if (myResults.Count > 1)
                        {
                            litNewAlerts.Text = myResults.Count.ToString() + " New Alerts.";
                        }
                    if (myResults.Count == 0)
                    {
                        litNewAlerts.Text = "0 New Alerts.";
                        //litNewAlerts.Text = userRes;
                    }

                    string htmlMain = "";
                    string date = "";
                    foreach (Result r in sortedList)
                    {
                        date = r.DateSearched.Value.ToString("MM/dd");
                        htmlMain += "<h2 class=\"date\">" + date + "</h2>";
                        htmlMain += "<h2 class=\"new\">New</h2>";
                        htmlMain += "<h2 class=\"comp\">" + r.Company + "</h2>";
                        htmlMain += "<h2 class=\"trig\">" + r.Triggers + "</h2>";
                        htmlMain += r.BodyText;
                        htmlMain += "<hr>";
                    }
                    litMain.Text = htmlMain;
                }
            }
            
        }

        protected void btnComp_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Companies.aspx");
        }

        protected void btnTrig_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Triggers.aspx");
        }

        protected void btnSignout_Click(object sender, EventArgs e)
        {
            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            authenticationManager.SignOut();
            Response.Redirect("~/TF.aspx");
        }

        protected void lnkSignout_Click(object sender, EventArgs e)
        {
            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            authenticationManager.SignOut();
            Response.Redirect("~/TF.aspx");
        }
    }
}