using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Trigger4.App_Code.Models;

namespace Trigger4.Admin
{
    public partial class ManageResults : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Result> allResults = new List<Result>();
            ResultModel m = new ResultModel();
            allResults = m.GetAllResults();
            int totalCount = allResults.Count;
            lblNumResults.Text = totalCount.ToString() + " total results" ;
        }
        protected bool goodResult(Result res)
        {
            //Use this for testing logic.
            bool isGood;
            isGood = true;
            return isGood;
        }

        protected void btnDisplayAll_Click(object sender, EventArgs e)
        {
            List<Result> allResults = new List<Result>();
            ResultModel m = new ResultModel();
            allResults = m.GetAllResults();
            string htmlMain = "";
            string date = "";
            foreach (Result r in allResults)
            {
                date = r.DateSearched.Value.ToString("MM/dd");
                htmlMain += "<h2 class=\"date\">" + date + "</h2>";
                htmlMain += "<h2 class=\"new\">New</h2>";
                htmlMain += "<h2 class=\"comp\">" + r.Company + "</h2>";
                htmlMain += "<h2 class=\"trig\">" + r.Triggers + "</h2>";
                htmlMain += r.BodyText;
                htmlMain += "<h2>" + goodResult(r).ToString() + "</h2>";
                htmlMain += "<hr>";
            }
            htmlMain = htmlMain.Replace("none;", "block;");
            litMain.Text = htmlMain;
        }

        protected void btnDeleteBlank_Click(object sender, EventArgs e)
        {
            List<Result> allResults = new List<Result>();
            ResultModel m = new ResultModel();
            allResults = m.GetAllResults();
            string status = "";
            foreach (Result r in allResults)
            {
                if (r.Triggers == "" || r.Triggers == null)
                {
                    status = m.DeleteResult(r.ID);
                }
            }
            lblStatus.Text = status;
        }

        protected void btnDeleteDays_Click(object sender, EventArgs e)
        {
            List<Result> allResults = new List<Result>();
            ResultModel m = new ResultModel();
            allResults = m.GetAllResults();
            int days = Convert.ToInt32(txtDays.Text);
            string status = "";
            DateTime deleteDate = DateTime.Now.AddDays(-days);
            foreach (Result r in allResults)
            {
                if (r.DateSearched < deleteDate)
                {
                    status = m.DeleteResult(r.ID);
                }
            }
            lblStatus.Text = status;
        }

        protected bool HasDuplicates(int id)
        {
            List<Result> allResults = new List<Result>();
            ResultModel m = new ResultModel();
            allResults = m.GetAllResults();
            Result myRes = m.GetResult(id);
            bool does = false;
            foreach (Result r in allResults)
            {
                if ((r.Company == myRes.Company) && (r.Triggers == myRes.Triggers))
                {
                    if (r.ID != id)
                    {
                        does = true;
                    }
                }
            }
            return does;
        }

        protected void btnDeleteDuplicates_Click(object sender, EventArgs e)
        {
            List<Result> allResults = new List<Result>();
            ResultModel m = new ResultModel();
            allResults = m.GetAllResults();
            string status = "";
            foreach (Result r in allResults)
            {
                if (HasDuplicates(r.ID))
                {
                    status = m.DeleteResult(r.ID);
                }
            }
        }
    }
}