using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Trigger4
{
    public partial class New : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var user = Context.User.Identity;
            /*
            if (user.IsAuthenticated)
            {
                litUserName.Text = Context.User.Identity.Name;

                litUserName.Visible = true;
                lnkLogout.Visible = true;
            }
            else
            {
                litUserName.Visible = false;
                lnkLogout.Visible = false;
            }
             */
        }

        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            authenticationManager.SignOut();
        }
    }
}