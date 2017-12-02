using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Web.Mail;
using System.Text;
using Trigger4.AppCode;

namespace Trigger4
{
    public partial class Main : System.Web.UI.Page
    {
        private const string AccountKey = "AHNwSNt5H24iDyClfGym1tG2FAR7JXku3BpmlKF4e4o";

        public static bool TestRelevance(string search, string tit, string descrip)
        {
            bool relevant = false;
            int found = 0;
            string[] searchTerms = search.Split(' ');
            foreach (string s in searchTerms)
            {
                if (tit.ToLower().Contains(s.ToLower()) || descrip.ToLower().Contains(s.ToLower()))
                {
                    found++;
                }
            }
            if (found == searchTerms.Length)
            {
                relevant = true;
            }
            return relevant;
        }
        
        //News(String Query, String Options, String Market, String Adult, Double? Latitude, Double? Longitude, 
        //String NewsLocationOverride, String NewsCategory, String NewsSortBy)

        [WebMethod]
        public static string[] MakeRequest(string search)
        {
            List<string> res = new List<string>();            
            // This is the query expression.
            string query = search;
            // Create a Bing container.
            string rootUrl = "https://api.datamarket.azure.com/Bing/Search";
            var bingContainer = new Bing.BingSearchContainer(new Uri(rootUrl));
            // The market to use.
            string market = "en-us";
            // Get news for business
            string newsCat = "rt_Business";
            // Configure bingContainer to use your credentials.
            bingContainer.Credentials = new NetworkCredential(AccountKey, AccountKey);
            // Build the query, limiting to 10 results.
            var newsQuery = bingContainer.News(query, null, market, null, null, null, null, newsCat, null);
            newsQuery = newsQuery.AddQueryOption("$top", 10);
            // Run the query and display the results.
            var newsResults = newsQuery.Execute();
            int daysThreshold = 40;
            DateTime currentDate = new DateTime();
            currentDate = DateTime.Now;
            DateTime thresholdDate = new DateTime();
            thresholdDate = currentDate.Subtract(TimeSpan.FromDays(daysThreshold));
            DateTime sixteen = new DateTime(2015, 10, 9, 12, 12,12);
            foreach (var result in newsResults)
            {
                if (result.Date > thresholdDate)
                {
                    //if (TestRelevance(search, result.Title, result.Description))
                    //{
                        res.Add(result.Title);
                        res.Add(result.Url);
                    //}
                }
            }
            return (res.ToArray());
        }

        protected void ClearFields()
        {
            LabelSuccess.Text = "Thank You.";
            LabelSuccess.Visible = true;
            TextBoxEmail.Text = "";
            TextBoxName.Text = "";
        }

        protected void ClearFieldsContact(bool isErr)
        {
            if (isErr)
            {
                txtEmailContact.Text = "";
                txtMessageContact.Text = "";
                lblSuccessContact.Text = "Something went wrong. Please email us at contact@triggerfind.com";
                lblSuccessContact.Visible = true;
            }
            else
            {
                txtEmailContact.Text = "";
                txtMessageContact.Text = "";
                lblSuccessContact.Text = "Thank You.";
                lblSuccessContact.Visible = true;
            }
        }

        private EmailList CreateEmailList()
        {
            EmailList e = new EmailList();

            e.Name = TextBoxName.Text;
            e.Email = TextBoxEmail.Text;
            //TODO: Add code to add collection of tags
            return e;
        }
        
        protected void ButtonSubmitEmail_Click(object sender, EventArgs e)
        {
            Trigger4.AppCode.EmailListModel model = new Trigger4.AppCode.EmailListModel();

            EmailList el = CreateEmailList();

            LabelSuccess.Text = model.InsertEmailList(el);

            ClearFields();
        }

        protected void btnSubmitContact_Click(object sender, EventArgs e)
        {
            string body = "From: " + txtEmailContact.Text + Environment.NewLine + Environment.NewLine + "Message: " + txtMessageContact.Text;
            string from = "";
            from = txtEmailContact.Text;
            if (from == "")
            {
                from = "No Email";
            }
            var mm = new System.Net.Mail.SmtpClient();
            mm.EnableSsl = true;
            mm.Host = "smtp.gmail.com";
            //mm.Port = 465;
            mm.Port = 587;
            mm.Timeout = 20000;
            mm.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            var cred = new System.Net.NetworkCredential("christopherburgdorff@gmail.com", "vcr357");
            mm.Credentials = cred;
            try
            {
                mm.Send(from, "contact@triggerfind.com", "Contact Form from Trigger Find", body);
                ClearFieldsContact(false);
            }
            catch (Exception ex)
            {
                string err = ex.ToString();
                ClearFieldsContact(true);
            }
        }
    }
}
