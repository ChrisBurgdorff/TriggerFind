using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Trigger4.App_Code.Models;

namespace Trigger4
{
    public partial class Settings : System.Web.UI.Page
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

            txtFirstName.Text = myUser.FirstName;

            txtLastName.Text = myUser.LastName;

            txtEmail.Text = myUser.Email;
        }
        private MyUser EditMyUser(MyUser existing)
        {
            MyUser mu = new MyUser();

            mu.AccountType = existing.AccountType;
            mu.BillingCycle = existing.BillingCycle;
            mu.Companies = existing.Companies;
            mu.Email = txtEmail.Text;
            mu.FirstName = txtFirstName.Text;
            mu.GUI = existing.GUI;
            mu.ID = existing.ID;
            mu.LastLogin = existing.LastLogin;
            mu.LastName = txtLastName.Text;
            mu.Newsletter = existing.Newsletter;
            mu.Results = existing.Results;
            mu.StartDate = existing.StartDate;
            mu.Triggers = existing.Triggers;
            mu.UserName = existing.UserName;

            return mu;
        }
        protected void lnkSignout_Click(object sender, EventArgs e)
        {
            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            authenticationManager.SignOut();
            Response.Redirect("~/TF.aspx");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            var user = Context.User.Identity;

            MyUserModel userModel = new MyUserModel();

            MyUser myUser = new MyUser();

            myUser = userModel.GetUserByName(user.Name);

            MyUser newUser = EditMyUser(myUser);

            litStatus.Text = userModel.UpdateMyUser(myUser.ID, newUser);
        }
    }
}