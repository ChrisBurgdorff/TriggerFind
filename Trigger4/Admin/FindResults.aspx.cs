using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Trigger4.App_Code.Models;

namespace Trigger4.Admin
{
    public partial class FindResults : System.Web.UI.Page
    {
        private const string AccountKey = "AHNwSNt5H24iDyClfGym1tG2FAR7JXku3BpmlKF4e4o";
        
        protected void Page_Load(object sender, EventArgs e)
        {
            FindAllResults();
        }

        public static string TestRelevance(string comp, string tit, string descrip)
        {
            string relevant = "False;";
            int found = 0;
            bool isRelevant = false;
            string[] bodyText = descrip.Split(' ');
            string[] titleText = descrip.Split(' ');
            string[] searchTerms = comp.Split(' ');
            /* Trigger Names (case sensitive af):
            Display Name::In Database
            "Hiring": "Hiring"
            "Merger/Acquisition": "Merger"
            "Sales Growth": "Sales"
            "Contracts": "Contracts"
            "Training": "Training"
            "New Office/Location": "Location"
            "CFO Leaving": "CFO"  */
            int numHiring = 0;
            int numMerger = 0;
            int numSales = 0;
            int numContracts = 0;
            int numTraining = 0;
            int numLocation = 0;
            int numCFO = 0;
            int numNew = 0;
            foreach (string s in searchTerms)
            {
                if (tit.ToLower().Contains(s.ToLower()) || descrip.ToLower().Contains(s.ToLower()))
                {
                    found++;
                }
            }
            for (int i = 0; i < bodyText.Length; i++)
            {
                if (bodyText[i].ToLower() == "hiring") { numHiring++; }
                if (bodyText[i].ToLower() == "merger" || bodyText[i].ToLower() == "acquire" || bodyText[i].ToLower() == "acquisition") { numMerger++; }
                if (bodyText[i].ToLower() == "growth") { numSales++; }
                if (bodyText[i].ToLower() == "contract") { numContracts++; }
                if (bodyText[i].ToLower() == "training") { numTraining++; }
                if (bodyText[i].ToLower() == "location") { numLocation++; }
                if (i < bodyText.Length - 1)
                {
                    if (bodyText[i].ToLower() == "new" && bodyText[i + 1].ToLower() == "cfo") { numCFO++; }
                }                
            }
            for (int j = 0; j < titleText.Length; j++)
            {
                if (titleText[j].ToLower() == "hiring") { numHiring+=2; }
                if (titleText[j].ToLower() == "merger" || titleText[j].ToLower() == "acquire" || titleText[j].ToLower() == "acquisition") { numMerger +=2; }
                if (titleText[j].ToLower() == "growth") { numSales = +2; }
                if (titleText[j].ToLower() == "contract") { numContracts +=2; }
                if (titleText[j].ToLower() == "training") { numTraining +=2; }
                if (titleText[j].ToLower() == "location") { numLocation+=2; }
                if (j < titleText.Length - 1)
                {
                    if (titleText[j].ToLower() == "new" && titleText[j + 1].ToLower() == "cfo") { numCFO+=2; }
                }
            }
            if (found == searchTerms.Length && searchTerms.Length == 1)
            {
                isRelevant = true;
            }
            if ((searchTerms.Length > 1) && (found >= (searchTerms.Length - 1)))
            {
                isRelevant = true;
            }
            if (isRelevant)
            {
                if ((numHiring > 0) && (numHiring > numMerger) && (numHiring > numSales) && (numHiring > numContracts) && (numHiring > numTraining) && (numHiring > numLocation) && (numHiring > numCFO))
                {
                    relevant = "Hiring";
                }
                if ((numMerger > 0) && (numMerger > numHiring) && (numMerger > numSales) && (numMerger > numContracts) && (numMerger > numTraining) && (numMerger > numLocation) && (numMerger > numCFO))
                {
                    relevant = "Merger";
                }
                if ((numSales > 0) && (numSales > numMerger) && (numSales > numHiring) && (numSales > numContracts) && (numSales > numTraining) && (numSales > numLocation) && (numSales > numCFO))
                {
                    relevant = "Sales";
                }
                if ((numContracts > 0) && (numContracts > numMerger) && (numContracts > numSales) && (numContracts > numHiring) && (numContracts > numTraining) && (numContracts > numLocation) && (numContracts > numCFO))
                {
                    relevant = "Contracts";
                }
                if ((numTraining > 0) && (numTraining > numMerger) && (numTraining > numSales) && (numTraining > numContracts) && (numTraining > numHiring) && (numTraining > numLocation) && (numTraining > numCFO))
                {
                    relevant = "Training";
                }
                if ((numLocation > 0) && (numLocation > numMerger) && (numLocation > numSales) && (numLocation > numContracts) && (numLocation > numTraining) && (numLocation > numHiring) && (numLocation > numCFO))
                {
                    relevant = "Location";
                }
                if ((numCFO > 0) && (numCFO > numMerger) && (numCFO > numSales) && (numCFO > numContracts) && (numCFO > numTraining) && (numCFO > numLocation) && (numCFO > numHiring))
                {
                    relevant = "CFO";
                }
            }
            return relevant;
        }

        //News(String Query, String Options, String Market, String Adult, Double? Latitude, Double? Longitude, 
        //String NewsLocationOverride, String NewsCategory, String NewsSortBy)

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
            newsQuery = newsQuery.AddQueryOption("$top", 25);
            // Run the query and display the results.
            var newsResults = newsQuery.Execute();
            int daysThreshold = 14;
            DateTime currentDate = new DateTime();
            currentDate = DateTime.Now;
            DateTime thresholdDate = new DateTime();
            thresholdDate = currentDate.Subtract(TimeSpan.FromDays(daysThreshold));
            DateTime sixteen = new DateTime(2015, 10, 9, 12, 12, 12);  
            foreach (var result in newsResults)
            {
                if (result.Date > thresholdDate)
                {
                    res.Add(result.Title);
                    res.Add(result.Url);
                    res.Add(result.Description);
                }
            }
            return (res.ToArray());
        }

        protected void FindAllResults()
        {
            CompanyModel cMod = new CompanyModel();
            ResultModel rMod = new ResultModel();
            MyUserModel muMod = new MyUserModel();

            List<Company> myComps = cMod.GetAllCompanies();
            List<MyUser> users = muMod.GetAllMyUsers();

            string[] myTrigs = new string[7];
            myTrigs[0] = "Hiring";
            myTrigs[1] = "Merger";
            myTrigs[2] = "Sales Growth";
            myTrigs[3] = "Contract";
            myTrigs[4] = "Training";
            myTrigs[5] = "New Location";
            myTrigs[6] = "New CFO";

            string finalStatus = "";

            int numRequests = 0;

            if ((myComps.Count < 1) || (myComps == null))
            {
                litStatus.Text = "Problem with companies list.";
                finalStatus += "Problem with companies list.";
            }
            foreach (Company c in myComps)
            {
                litStatus.Text = "Checking for news about " + c.Name + ".";
                finalStatus += "Checking for news about " + c.Name + ".";
                string sear = c.Name;
                string[] res = MakeRequest(sear);
                numRequests++;
                string htmlBody = "";
                if (res.Length < 1)
                {
                    litStatus.Text = "Nothing found for " + c.Name + ".";
                    finalStatus += "Nothing found for " + c.Name + ".";
                }
                else
                {
                    List<int> skips = new List<int>();
                    string finalTrigger = "";
                    for (int j = 0; j < res.Length; j=j+3)
                    {
                        string title = res[j];
                        string desc = res[j + 2];
                        string trig = TestRelevance(c.Name, title, desc);
                        if (trig == "False")
                        {
                            skips.Add(j);
                            skips.Add(j + 1);
                            skips.Add(j + 2);
                        }
                        else
                        {
                            finalTrigger = trig;
                        }
                    }
                    litStatus.Text = "Creating new result for " + c.Name + ".";
                    finalStatus += "Creating new result for " + c.Name + ".";
                    Result newRes = new Result();
                    string myComp = c.Name;
                    newRes.Company = myComp;
                    newRes.DateSearched = DateTime.Now;
                    //FIX THIS
                    newRes.Triggers = finalTrigger;
                    //FIX THIS
                    htmlBody += "<ul>";
                    for (int j = 0; j < res.Length; j = j + 3)
                    {
                        if (!skips.Contains(j))
                        {
                            htmlBody += "<li>" + "<a href=\"" + res[j + 1] + "\">" + res[j] + "</a>" + "</li>";
                        }
                        if (j == (res.Length - 3))
                        {
                            htmlBody += "</ul>";
                        }
                    } //For
                    newRes.BodyText = htmlBody;
                    rMod.InsertResult(newRes);
                    //Put result in user's shit
                    foreach (MyUser m in users)
                    {
                        string uComps = m.Companies;
                        if ((myComp!=null)&&(uComps!=null)&&(uComps.Contains(myComp))&&(m.Triggers.Contains(finalTrigger)))
                        {
                            string resultString = m.Results;
                            string newResultString = "";
                            if ((resultString == null) || (resultString == ""))
                            {
                                newResultString = newRes.ID.ToString();
                            }
                            else
                            {
                                newResultString = newRes.ID.ToString() + "," + resultString;
                            }
                            MyUser newUse = new MyUser();
                            newUse.AccountType = m.AccountType;
                            newUse.BillingCycle = m.BillingCycle;
                            newUse.Companies = m.Companies;
                            newUse.Email = m.Email;
                            newUse.FirstName = m.FirstName;
                            newUse.GUI = m.GUI;
                            newUse.ID = m.ID;
                            newUse.LastLogin = m.LastLogin;
                            newUse.LastName = m.LastName;
                            newUse.Newsletter = m.Newsletter;
                            newUse.Results = newResultString;
                            newUse.StartDate = m.StartDate;
                            newUse.Triggers = m.Triggers;
                            newUse.UserName = m.UserName;
                            muMod.UpdateMyUser(m.ID, newUse);
                        }//if ucomps
                    }//foreach 
                    } //if res.length
            } // foreach Company c in comps
            finalStatus += "This operation took " + numRequests.ToString() + " requests.";
            litFinalStatus.Text = finalStatus;
        } //FindAllResults()

        protected void btnFindAll_Click(object sender, EventArgs e)
        {
            FindAllResults();
        }
    }
}