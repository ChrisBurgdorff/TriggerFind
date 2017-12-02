using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Trigger4.Admin
{
    public partial class ViewPosts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridViewPosts_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = GridViewPosts.Rows[e.NewEditIndex];

            int rowID = Convert.ToInt32(row.Cells[1].Text);

            Response.Redirect("~/Admin/AddPost.aspx?id=" + rowID);
        }


        protected void btnNewPost_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/triggerblog/wp-login.php");    
        }

        protected void GridViewPosts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnEmailList_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/EmailList.aspx");
        }

        protected void btnUsers_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/ManageUsers.aspx");
        }

        protected void btnFindResults_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Tasks/FindResults.aspx");
        }

        protected void btnManageResults_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/ManageResults.aspx");
        }
    }
}