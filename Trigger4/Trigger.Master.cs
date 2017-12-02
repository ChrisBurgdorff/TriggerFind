using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using Trigger4.AppCode;
using System.Web.Mail;
using System.Text;

namespace Trigger4
{
    public partial class Trigger : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /*
        [WebMethod]
        public static string SendContact(string email, string message)
        {
            string result = "";
            try{
            string body = "From: " + email + Environment.NewLine +  Environment.NewLine + message;
            var mm = new System.Net.Mail.SmtpClient();
            mm.EnableSsl = true;
            mm.Host = "smtp.gmail.com";
            //mm.Port = 465;
            mm.Port = 587;
            mm.Timeout = 20000;
            mm.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            var cred = new System.Net.NetworkCredential("christopherburgdorff@gmail.com", "vcr357");
            mm.Credentials = cred;
            mm.Send(email, "contact@triggerfind.com", "Contact Form from Trigger Find", message);
            result = "Submitted.  Thank you!";
            }
            catch (Exception e)
            {
                result = "Something went wrong. Sorry about that, please email us at Contact@triggerfind.com";
            }
            return (result);
        } */
    }
}