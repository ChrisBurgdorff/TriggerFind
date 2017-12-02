using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Trigger4.Admin
{
    public partial class ManageUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void grdUsers_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = grdUsers.Rows[e.NewEditIndex];
            int rowID = Convert.ToInt32(row.Cells[1].Text);
            Response.Redirect("~/Admin/EditUser.aspx?id=" + rowID);
        }

        protected void grdCompanies_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = grdCompanies.Rows[e.NewEditIndex];
            int rowID = Convert.ToInt32(row.Cells[1].Text);
            Response.Redirect("~/Admin/EditCompany.aspx?id=" + rowID);
        }

        protected void grdResults_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = grdResults.Rows[e.NewEditIndex];
            int rowID = Convert.ToInt32(row.Cells[1].Text);
            Response.Redirect("~/Admin/EditResults.aspx?id=" + rowID);
        }
    }
}