using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Trigger4.App_Code.Models;

namespace Trigger4
{
    public partial class Success : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var user = Context.User.Identity;

            MyUserModel userModel = new MyUserModel();

            MyUser u = new MyUser();

            u = userModel.GetUserByName(user.Name);



            MyUser newUse = new MyUser();
            newUse.AccountType = 2;
            newUse.BillingCycle = u.BillingCycle;
            newUse.Companies = u.Companies;
            newUse.Email = u.Email;
            newUse.FirstName = u.FirstName;
            newUse.GUI = u.GUI;
            newUse.ID = u.ID;
            newUse.LastLogin = u.LastLogin;
            newUse.LastName = u.LastName;
            newUse.Newsletter = u.Newsletter;
            newUse.Results = u.Results;
            newUse.StartDate = u.StartDate;
            newUse.Triggers = u.Triggers;
            newUse.UserName = u.UserName;
            userModel.UpdateMyUser(u.ID, newUse);

            Response.Redirect("~/Home.aspx");
        }
    }
}