using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Trigger4.Admin
{
    public partial class EditCompany : System.Web.UI.Page
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
            Trigger4.App_Code.Models.CompanyModel compModel = new Trigger4.App_Code.Models.CompanyModel();
            Company comp = compModel.GetCompany(id);

            txtName.Text = comp.Name;
            txtSymbol.Text = comp.Symbol;
            txtAlternateName.Text = comp.AlternateName;
            txtCEO.Text = comp.CEO;
            txtCFO.Text = comp.CFO;
            txtIndustry.Text = comp.Industry;
            txtIndustry2.Text = comp.Industry2;

        }

        private Company CreateCompany()
        {
            Company c = new Company();

            c.Name = txtName.Text;
            c.Symbol = txtSymbol.Text;
            c.AlternateName = txtAlternateName.Text;
            c.CEO = txtCEO.Text;
            c.CFO = txtCFO.Text;
            c.Industry = txtIndustry.Text;
            c.Industry2 = txtIndustry2.Text;

            return c;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Trigger4.App_Code.Models.CompanyModel model = new Trigger4.App_Code.Models.CompanyModel();
            Company c = CreateCompany();

            if (!string.IsNullOrWhiteSpace(Request.QueryString["id"]))
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                lblResult.Text = model.UpdateCompany(id, c);
            }
            else
            {
                lblResult.Text = "Update Failed - no id";
            }
        }

    }
}