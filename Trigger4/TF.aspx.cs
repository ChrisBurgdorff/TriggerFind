using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace Trigger4
{
    public partial class TF : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            var user = Context.User.Identity;

            if (user.IsAuthenticated)
            {
                //Response.Redirect("~/Home.aspx");
                //Uncomment before uploading
            }
        }

        private MyUser CreateMyUser(string gu)
        {
            MyUser mu = new MyUser();

            mu.GUI = gu;
            mu.Email = txtEmail.Text;
            mu.AccountType = 0;
            mu.BillingCycle = 0;
            mu.LastLogin = DateTime.Now;
            mu.UserName = txtUsername.Text;
            mu.StartDate = DateTime.Now;
            mu.Newsletter = "Yes";

            return mu;
        }

        protected void register_Click(object sender, EventArgs e)
        {
            UserStore<IdentityUser> userStore = new UserStore<IdentityUser>();

            userStore.Context.Database.Connection.ConnectionString = 
                System.Configuration.ConfigurationManager.
                ConnectionStrings["triggerDBConnectionString"].ConnectionString;

            UserManager<IdentityUser> manager = new UserManager<IdentityUser>(userStore);

            //Create new user and store in DB
            IdentityUser user = new IdentityUser();
            user.UserName = txtUsername.Text;

            //Store new user in MyUser database
            Trigger4.App_Code.Models.MyUserModel model = new Trigger4.App_Code.Models.MyUserModel();

            string g = user.Id;
            MyUser m = CreateMyUser(g);

            

                try
                {
                    //Create user object and add it to the Database
                    IdentityResult result = manager.Create(user, txtPassword.Text);

                    if (result.Succeeded)
                    {
                        //Store user in MyUser dateabase
                        litStatus.Text = model.InsertMyUser(m);
                        //litStatus.Text = "Got Here."

                        //Store user in database
                        var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;

                        //Set to login user by cookie
                        var userIdentity = manager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                        //Login user and redirect to Main (for now)
                        authenticationManager.SignIn(new AuthenticationProperties(), userIdentity);
                        Response.Redirect("~/signup.html");
                    }
                    else
                    {
                        litStatus.Text = result.Errors.FirstOrDefault();
                    }
                }
                catch (Exception ex)
                {
                    litStatus.Text = ex.ToString();
                }
        }

        protected void login_Click(object sender, EventArgs e)
        {
            UserStore<IdentityUser> userStore = new UserStore<IdentityUser>();

            userStore.Context.Database.Connection.ConnectionString =
                System.Configuration.ConfigurationManager.
                ConnectionStrings["triggerDBConnectionString"].ConnectionString;

            UserManager<IdentityUser> manager = new UserManager<IdentityUser>(userStore);

            var user = manager.Find(txtUserLogin.Text, txtPasswordLogin.Text);

            if (user != null)
            {
                var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                var userIdentity = manager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                //Sign in
                authenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = false
                    }, userIdentity);

                //Redirect for now
                Response.Redirect("~/Home.aspx");
            }
            else
            {
                litStatusLogin.Text = "Invalid Username or password";
            }
        }

        protected void btnBlog_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/triggerblog/");
        }

        protected void btnMobileDownload_Click(object sender, EventArgs e)
        {
            Response.Redirect("https://play.google.com/store/apps/details?id=com.triggerfind.triggerfind&hl=en");
        }
    }
}