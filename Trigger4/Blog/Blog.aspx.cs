using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.Mail;
using System.Text;

namespace Trigger4.Blog
{
    public partial class Blog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                if (!String.IsNullOrWhiteSpace(Request.QueryString["id"]))
                {
                    int id = Convert.ToInt32(Request.QueryString["id"]);
                    Trigger4.AppCode.PostModel model = new Trigger4.AppCode.PostModel();
                    List<Post> blogPosts = new List<Post>();
                    blogPosts.Add(model.GetPost(id));
                    DisplayPosts(blogPosts, 1, 1);
                }
                else if (!String.IsNullOrWhiteSpace(Request.QueryString["page"]))
                {
                    int page = Convert.ToInt32(Request.QueryString["page"]);
                    Trigger4.AppCode.PostModel model = new Trigger4.AppCode.PostModel();
                    List<Post> blogPosts = new List<Post>();
                    blogPosts = model.GetAllPosts();
                    DisplayPosts(blogPosts, 1, page);
                }
                else if (!String.IsNullOrWhiteSpace(Request.QueryString["tag"]))
                {
                    string tag = Request.QueryString["tag"];
                    Trigger4.AppCode.PostModel model = new Trigger4.AppCode.PostModel();
                    List<Post> blogPosts = new List<Post>();
                    blogPosts = model.GetPostsByTag();
                    DisplayPosts(blogPosts, 1, 1);
                }
                else
                {
                    
                    Trigger4.AppCode.PostModel model = new Trigger4.AppCode.PostModel();
                    
                    List<Post> blogPosts = new List<Post>();
                    
                    blogPosts = model.GetAllPosts();
                    
                    DisplayPosts(blogPosts, 1, 1);
                }       
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

        protected void AddMetaTags(Post pos)
        {
            HtmlGenericControl metaURL = new HtmlGenericControl("meta");
            metaURL.Attributes["property"] = "og:url";
            metaURL.Attributes["content"] = "http://www.triggerfind.com/Blog/Blog.aspx?id=" + pos.ID.ToString();
            Page.Header.Controls.Add(metaURL);

            HtmlGenericControl metaType = new HtmlGenericControl("meta");
            metaType.Attributes["property"] = "og:type";
            metaType.Attributes["content"] = "website";
            Page.Header.Controls.Add(metaType);

            HtmlGenericControl metaTitle = new HtmlGenericControl("meta");
            metaTitle.Attributes["property"] = "og:title";
            metaTitle.Attributes["content"] = pos.Title;
            Page.Header.Controls.Add(metaTitle);

            HtmlGenericControl metaDescription = new HtmlGenericControl("meta");
            metaDescription.Attributes["property"] = "og:description";
            metaDescription.Attributes["content"] = "Free Business Only News About Your Customers And Prospects";
            Page.Header.Controls.Add(metaDescription);

            HtmlGenericControl metaImage = new HtmlGenericControl("meta");
            metaImage.Attributes["property"] = "og:image";
            metaImage.Attributes["content"] = "http://www.triggerfind.com/images/homepage.png";
            Page.Header.Controls.Add(metaImage);
        }

        public string DetermineMonth(Post pos)
        {
            string temp ="";
            if(pos.DateTime.Month==1) { temp="Jan";} 
            else if(pos.DateTime.Month==2) { temp="Feb";} 
            else if(pos.DateTime.Month==3) { temp="Mar";} 
            else if(pos.DateTime.Month==4) { temp="Apr";} 
            else if(pos.DateTime.Month==5) { temp="May";} 
            else if(pos.DateTime.Month==6) { temp="Jun";} 
            else if(pos.DateTime.Month==7) { temp="Jul";} 
            else if(pos.DateTime.Month==8) { temp="Aug";} 
            else if(pos.DateTime.Month==9) { temp="Sep";} 
            else if(pos.DateTime.Month==10) { temp="Oct";} 
            else if(pos.DateTime.Month==11) { temp="Nov";} 
            else if(pos.DateTime.Month==12) { temp="Dec";} 
            return temp;
        }
        public string DetermineMonth(Comment com)
        {
            string temp = "";
            if (com.DateTime.Month == 1) { temp = "Jan"; }
            else if (com.DateTime.Month == 2) { temp = "Feb"; }
            else if (com.DateTime.Month == 3) { temp = "Mar"; }
            else if (com.DateTime.Month == 4) { temp = "Apr"; }
            else if (com.DateTime.Month == 5) { temp = "May"; }
            else if (com.DateTime.Month == 6) { temp = "Jun"; }
            else if (com.DateTime.Month == 7) { temp = "Jul"; }
            else if (com.DateTime.Month == 8) { temp = "Aug"; }
            else if (com.DateTime.Month == 9) { temp = "Sep"; }
            else if (com.DateTime.Month == 10) { temp = "Oct"; }
            else if (com.DateTime.Month == 11) { temp = "Nov"; }
            else if (com.DateTime.Month == 12) { temp = "Dec"; }
            return temp;
        }

        private Comment CreateComment(string newComment, int id, string name)
        {
            Comment c = new Comment();
            string temp = newComment;
            temp = Server.HtmlEncode(temp);
            temp = temp.Replace(" ", "&nbsp;");
            temp = temp.Replace("\r\n", "<br>");
            c.Body = temp;
            c.PostID = id;
            c.DateTime = DateTime.Now;
            c.Name = name;
            return c;
        }
              
        protected void AddComment(string id)
        {
            int iidd = Convert.ToInt32(id);
            Trigger4.AppCode.CommentModel cmod = new Trigger4.AppCode.CommentModel();
             ContentPlaceHolder cph = (ContentPlaceHolder)this.Master.FindControl("ContentPlaceHolder1");
             string bod = (((TextBox)cph.FindControl(id + "txt")).Text);
             string name = (((TextBox)cph.FindControl(id + "name")).Text);
             Label result = ((Label)cph.FindControl(id + "result"));
             Comment c = CreateComment(bod, iidd, name);
             result.Text = "Comment " + cmod.InsertComment(c);
        }
        
        protected void btnComment_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            AddComment(button.ID);
            // identify which button was clicked and perform necessary actions
        }

        protected void btnMore_Click(object sender, EventArgs e)
        {           
            int page = 1;
            if (!String.IsNullOrWhiteSpace(Request.QueryString["page"]))
            {
                page = Convert.ToInt32(Request.QueryString["page"]);
            }
            page++;
            Response.Redirect("~/Blog/Blog.aspx?page=" + page.ToString());
        }
        
        protected void DisplayPosts(List<Post> posts, int max, int page)
        {
            Trace.Write("InDisplay");
            int amountOfDrafts = 0;
            if (posts != null)
            {
                foreach (Post po in posts)
                {
                    if ((po.IsDraft == "Yes") || (po.IsDraft == null))
                    {
                        amountOfDrafts++;
                    }
                }
            }
            if (posts != null)
            {
                if (page > 1)
                {
                    if (posts.Count <= (page-1)*max)
                    {
                        Response.Redirect("~/Blog/Blog.aspx");
                    } 
                    else
                    {
                        posts.RemoveRange(0,(page-1)*max);
                    }
                }
                Trigger4.AppCode.CommentModel cmod = new Trigger4.AppCode.CommentModel();
                List<Comment> comments = new List<Comment>();
                comments = cmod.GetAllComments();

                Panel sidebarPanel = new Panel();
                sidebarPanel.Controls.Add(new Literal { Text = "<div class=\"sidebarBlog\">" });
                sidebarPanel.Controls.Add(new Literal { Text = "<h2>Recent Posts</h2>" });
                int maxLinks = 7;
                int numLinks = 0;
                Trigger4.AppCode.PostModel model = new Trigger4.AppCode.PostModel();
                List<Post> blogPosts = new List<Post>();
                blogPosts = model.GetAllPosts();
                foreach(Post p in blogPosts)
                {
                    numLinks++;
                    if (numLinks < maxLinks)
                    {
                        sidebarPanel.Controls.Add(new Literal { Text = "<a class=\"sidebarLink\" href=\"" + "/Blog/Blog.aspx?id=" + p.ID + "\">" + p.Title + "</a>" });
                        sidebarPanel.Controls.Add(new Literal { Text = "<br>" });       
                    }
                    
                }
                sidebarPanel.Controls.Add(new Literal { Text = "</div>" });

                pnlSidebar.Controls.Add(sidebarPanel);

                foreach (Post p in posts.Take(max))
                {
                    AddMetaTags(p);
                    Panel postPanel = new Panel();
                    Label lblTitle = new Label();
                    Button btnComment = new Button();Button button = new Button();
                    btnComment.Click += new EventHandler(btnComment_Click);
                    btnComment.ID = p.ID.ToString();
                    TextBox txtComment = new TextBox();
                    txtComment.ID = p.ID.ToString() + "txt";
                    btnComment.CssClass = "btn";
                    btnComment.Text = "Comment";
                    txtComment.TextMode = TextBoxMode.MultiLine;
                    txtComment.Height = 75;
                    txtComment.Width = 450;
                    txtComment.CssClass = "commentBox";
                    TextBox txtName = new TextBox();
                    txtName.ID = p.ID.ToString() + "name";
                    txtName.Width = 250;
                    Label lblName = new Label();
                    Label lblComment = new Label();
                    Label lblResult = new Label();
                    lblName.CssClass = "labels";
                    lblName.Text = "Name:";
                    lblComment.CssClass = "labels";
                    lblComment.Text = "Comment:";
                    lblResult.CssClass = "labels";
                    lblResult.Text = "";
                    lblResult.ID = p.ID.ToString() + "result";

                    if (p.IsDraft == "No")
                    {
                        string month = DetermineMonth(p);
                        int commentCount = 0;
                        postPanel.Controls.Add(new Literal { Text = "<div class=\"blog\">" });
                        postPanel.Controls.Add(new Literal { Text = "<div class=\"date\">" });
                        postPanel.Controls.Add(new Literal { Text = "<h3>" + month + "</h3>" });
                        postPanel.Controls.Add(new Literal { Text = "<p>" + p.DateTime.Day + "</p>" });
                        postPanel.Controls.Add(new Literal { Text = "</div>" });
                        postPanel.Controls.Add(new Literal { Text = "<h2>" + p.Title + "</h2>" });
                        postPanel.Controls.Add(new Literal { Text = "<br>" });
                        postPanel.Controls.Add(new Literal { Text = "<p>" + p.Body + "</p>" });
                        postPanel.Controls.Add(new Literal { Text = "<br>" });
                        foreach (Comment co in comments)
                        {
                            if (co.PostID == p.ID)
                            {
                                commentCount++;
                            }
                        }
                        if(commentCount==0)
                        {
                            postPanel.Controls.Add(new Literal { Text = "<p>0 Comments</p>" });
                        }
                        else
                        {
                            postPanel.Controls.Add(new Literal { Text = "<a href=\"#\" class=\"commentsLink\">" + commentCount.ToString() + " Comments</a>" });
                        }
                        postPanel.Controls.Add(new Literal { Text = "<a href=\"#\" class=\"addCommentLink\">Add Comment</a>" });
                        postPanel.Controls.Add(lblResult);
                        //postPanel.Controls.Add(txtComment);
                        //Add Button
                        if ((posts.Count-amountOfDrafts) > posts.Take(max).Count())
                        {
                            Button btnMore = new Button();
                            btnMore.Click += new EventHandler(btnMore_Click);
                            btnMore.CssClass = "btn";
                            btnMore.Text = "Older Posts";
                            postPanel.Controls.Add(btnMore);
                        }
                        //40x132
                        /////////////////////////////////////////////////////////////////////////////////////////// Add Share Buttons
                        postPanel.Controls.Add(new Literal { Text = "<br>" });
                        postPanel.Controls.Add(new Literal { Text = "<div class=\"shareButtons\">"});
                        postPanel.Controls.Add(new Literal { Text = "<div class=\"fb-share-button\" data-href=\"http://www.triggerfind.com/Blog/Blog.aspx?id=" + p.ID });
                        postPanel.Controls.Add(new Literal { Text = "\" data-layout=\"button\"> </div>" });
                        postPanel.Controls.Add(new Literal { Text = "<a href=\"https://twitter.com/share?url=http://www.triggerfind.com/Blog/Blog.aspx?id=" + p.ID + "&text=" + p.Title + "\">" });
                        postPanel.Controls.Add(new Literal { Text = "<img src=\"http://www.triggerfind.com/images/twitter.png\" width=\"24px\" height=\"24px\">" });
                        postPanel.Controls.Add(new Literal {Text = "</a>"});
                        postPanel.Controls.Add(new Literal { Text = "<a href=\"https://www.linkedin.com/shareArticle?mini=true&url=http://www.triggerfind.com/Blog/Blog.aspx?id=" + p.ID + "&title=" + HttpUtility.UrlEncode(p.Title) + "\">" });
                        postPanel.Controls.Add(new Literal { Text = "<img src=\"http://www.triggerfind.com/images/linkedin.png\" width=\"58px\" height=\"24px\">" });
                        postPanel.Controls.Add(new Literal {Text = "</a>"});
                        postPanel.Controls.Add(new Literal { Text = "<a href=\"http://www.facebook.com/sharer/sharer.php?u=http://www.triggerfind.com/Blog/Blog.aspx?id=" + p.ID + "\">" });
                        postPanel.Controls.Add(new Literal { Text = "<img src=\"http://www.triggerfind.com/images/facebook.png\" width=\"79px\" height=\"24px\">" });
                        postPanel.Controls.Add(new Literal { Text = "</a>" });
                        postPanel.Controls.Add(new Literal { Text = "</div>" });
                        ////////////////////End Share Buttons
                        postPanel.Controls.Add(new Literal { Text = "<div class=\"commentMaker\">" });
                        postPanel.Controls.Add(new Literal { Text = "<br>" });
                        postPanel.Controls.Add(lblName);
                        postPanel.Controls.Add(txtName);
                        postPanel.Controls.Add(new Literal { Text = "<br>" });
                        postPanel.Controls.Add(lblComment);
                        postPanel.Controls.Add(new Literal { Text = "<br>" });
                        postPanel.Controls.Add(txtComment);
                        postPanel.Controls.Add(btnComment);
                        postPanel.Controls.Add(new Literal { Text = "" });
                        postPanel.Controls.Add(new Literal { Text = "" });
                        postPanel.Controls.Add(new Literal { Text = "" });
                        postPanel.Controls.Add(new Literal { Text = "</div>" });
                        postPanel.Controls.Add(new Literal { Text = "</div>" });
                        //Add Sidebar
                        
                        //End Sidebar
                        postPanel.Controls.Add(new Literal { Text = "<div class=\"comments\">" });
                        foreach (Comment c in comments)
                        {
                            if (c.PostID == p.ID)
                            {
                                string mon = DetermineMonth(c);
                                postPanel.Controls.Add(new Literal { Text = "<p>" });
                                postPanel.Controls.Add(new Literal { Text = "Posted by " + c.Name + " on " + mon + " " + c.DateTime.Day + ":" + "</p>" });
                                postPanel.Controls.Add(new Literal { Text = "<p>" });
                                postPanel.Controls.Add(new Literal { Text = c.Body });
                                postPanel.Controls.Add(new Literal { Text = "</p>" });
                                postPanel.Controls.Add(new Literal { Text = "<br>" });
                            }
                        }
                        postPanel.Controls.Add(new Literal { Text = "</div>" });
                        pnlPosts.Controls.Add(postPanel);
                        Trace.Write("EndDisplay");
                    }
                }
            }   
        }
    }
}