using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Trigger4.Admin
{
    public partial class EditResult : System.Web.UI.Page
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
            Trigger4.App_Code.Models.ResultModel resModel = new Trigger4.App_Code.Models.ResultModel();
            Result res = resModel.GetResult(id);

            txtCompany.Text = res.Company;
            txtTriggers.Text = res.Triggers;
            txtDateSearched.Text = res.DateSearched.ToString();
            txtBodyText.Text = res.BodyText;

        }

        private Result CreateResult()
        {
            if (!String.IsNullOrWhiteSpace(Request.QueryString["id"]))
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                Result r = new Result();
                Trigger4.App_Code.Models.ResultModel resModel = new Trigger4.App_Code.Models.ResultModel();
                Result res = resModel.GetResult(id);

                r.Company = txtCompany.Text;
                r.Triggers = txtTriggers.Text;
                r.BodyText = txtBodyText.Text;
                r.DateSearched = res.DateSearched;

                return r;
            }
            else
            {
                return null;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Trigger4.App_Code.Models.ResultModel model = new Trigger4.App_Code.Models.ResultModel();
            Result r = CreateResult();

            if (!string.IsNullOrWhiteSpace(Request.QueryString["id"]))
            {
                if (r == null)
                {
                    lblResult.Text = "Update Failed - r is null.";
                }
                else
                {
                    int id = Convert.ToInt32(Request.QueryString["id"]);
                    lblResult.Text = model.UpdateResult(id, r);
                }
            }
            else
            {
                lblResult.Text = "Update Failed - no id";
            }
        }

    }
}