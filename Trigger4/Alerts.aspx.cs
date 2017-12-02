using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Trigger4.App_Code.Models;

namespace Trigger4
{
    public partial class Alerts : System.Web.UI.Page
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

            var user = Context.User.Identity;

            MyUserModel userModel = new MyUserModel();

            MyUser myUser = new MyUser();

            myUser = userModel.GetUserByName(user.Name);

            litUsername.Text = myUser.UserName;

            if (myUser != null)
            {
                if (myUser.Results != null)
                {
                    string userRes = myUser.Results;
                    ResultModel resModel = new ResultModel();
                    List<Trigger4.Result> myResults = new List<Trigger4.Result>();
                    myResults = resModel.GetResultsForUser(userRes);

                    string htmlMain = "";
                    string date = "";
                    foreach (Result r in myResults)
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

        protected void lnkSignout_Click(object sender, EventArgs e)
        {
            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            authenticationManager.SignOut();
            Response.Redirect("~/TF.aspx");
        }//Fill Page
    }//Partial Class Alerts
}//Namespace