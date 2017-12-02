using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Trigger4.Admin
{
    public partial class AddPost : System.Web.UI.Page
    {
        private Post CreatePost()
        {
            Post p = new Post();            

            p.Title = txtTitle.Text;
            //TODO: Add code to add collection of tags
            p.DateTime = DateTime.Now;
            string temp = txtBody.Text;
            temp = temp.Replace("\r\n", "<br>");
            p.Body = temp;
            p.Tags1 = txtTags.Text;
            if (chkDraft.Checked)
            {
                p.IsDraft = "Yes";
            }
            else {
                p.IsDraft = "No";
            }

            return p;

        }

        private Tag CreateTag(string newTag)
        {
            Tag t = new Tag();
            t.Name = newTag;
            return t;
        }

        private void FillPage(int id)
        {
            Trigger4.AppCode.PostModel postModel = new Trigger4.AppCode.PostModel();
            Post post = postModel.GetPost(id);

            txtTitle.Text = post.Title;
            txtBody.Text = post.Body;

        }

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

        protected void AddNewTags()
        {
            Trigger4.AppCode.TagModel mod = new Trigger4.AppCode.TagModel();
            string tagList = txtTags.Text;
            string lowerTagList = tagList.ToLower();
            string[] newTags = lowerTagList.Split(' ');
            bool foundInOld = false;
            List<Tag> oldTags = mod.GetAllTags();
            for(int i=0;i<newTags.Length;i++)
            {
                foundInOld = false;
                for (int j = 0; j < oldTags.Count; j++)
                {
                    if (oldTags[j].Name == newTags[i])
                    {
                        foundInOld = true;
                    }
                    if (!foundInOld)
                    {
                        AddTag(newTags[i]);
                    }
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Trigger4.AppCode.PostModel model = new Trigger4.AppCode.PostModel();

            Post p = CreatePost();

            if (!string.IsNullOrWhiteSpace(Request.QueryString["id"]))
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                lblResult.Text = model.UpdatePost(id, p);
            }
            else
            {
                lblResult.Text = model.InsertPost(p);
            }
        }

        protected void AddTag(string newTag)
        {
            Trigger4.AppCode.TagModel mod = new Trigger4.AppCode.TagModel();

            Tag t = CreateTag(newTag);

            lblTagResult.Text = mod.InsertTag(t);
        }

        protected void btnViewPosts_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/ViewPosts.aspx");
        }
        }
    }
