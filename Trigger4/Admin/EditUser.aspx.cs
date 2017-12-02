using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Trigger4.Admin
{
    public partial class EditUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!String.IsNullOrWhiteSpace(Request.QueryString["id"]))
                {
                    int id = Convert.ToInt32(Request.QueryString["id"]);
                    FillPage(id);
                }
            }
        }

        private void FillPage(int id)
        {
            Trigger4.App_Code.Models.MyUserModel muModel = new Trigger4.App_Code.Models.MyUserModel();
            MyUser mu = muModel.GetMyUser(id);

            txtGUI.Text = mu.GUI;
            txtUserName.Text = mu.UserName;
            txtFirstName.Text = mu.FirstName;
            txtLastName.Text = mu.LastName;
            txtCompanies.Text = mu.Companies;
            txtTriggers.Text = mu.Triggers;
            txtEmail.Text = mu.Email;
            txtAccountType.Text = mu.AccountType.ToString();
            txtStartDate.Text = mu.StartDate.ToString();
            txtBillingCycle.Text = mu.BillingCycle.ToString();
            txtLastLogin.Text = mu.LastLogin.ToString();
            txtNewsletter.Text = mu.Newsletter;
            txtResults.Text = mu.Results;

        }

        private MyUser CreateMyUser()
        {
            if (!String.IsNullOrWhiteSpace(Request.QueryString["id"]))
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                MyUser m = new MyUser();
                Trigger4.App_Code.Models.MyUserModel resModel = new Trigger4.App_Code.Models.MyUserModel();
                MyUser res = resModel.GetMyUser(id);

                m.GUI = res.GUI;
                m.UserName = txtUserName.Text;
                m.FirstName = txtFirstName.Text;
                m.LastName = txtLastName.Text;
                m.Companies = txtCompanies.Text;
                m.Triggers = txtTriggers.Text;
                m.Email = txtEmail.Text;
                m.AccountType = Convert.ToInt32(txtAccountType.Text);
                m.StartDate = res.StartDate;
                m.BillingCycle = Convert.ToInt32(txtBillingCycle.Text);
                m.LastLogin = res.LastLogin;
                m.Newsletter = txtNewsletter.Text;
                m.Results = txtResults.Text;

                return m;
            }
            else
            {
                return null;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Trigger4.App_Code.Models.MyUserModel model = new Trigger4.App_Code.Models.MyUserModel();
            MyUser m = CreateMyUser();

            if (!string.IsNullOrWhiteSpace(Request.QueryString["id"]))
            {
                if (m == null)
                {
                    lblResult.Text = "Update Failed. M is null.";
                }
                else
                {
                    int id = Convert.ToInt32(Request.QueryString["id"]);
                    lblResult.Text = model.UpdateMyUser(id, m);
                }
            }
            else
            {
                lblResult.Text = "Update Failed - no id";
            }
        }

    }
}