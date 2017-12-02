using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace Trigger4.Blog
{
    public partial class stream : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreateFile_Click(object sender, EventArgs e)
        {
            using (StreamWriter sw = new StreamWriter("/Blog/testa.html"))
            {
                sw.WriteLine("<html>");
                sw.WriteLine("<head>");
                sw.WriteLine("<link href=\"/Styles/trigger.css\" rel=\"stylesheet\" type=\"text/css\">");
                sw.WriteLine("<title>This is a test</title>");
                sw.WriteLine("</head>");
                sw.WriteLine("<body>");
                sw.WriteLine("<h1>Test is working</h1>");
                sw.WriteLine("</body>");
                sw.WriteLine("</html>");
            }
        }

        protected void btnOverwriteFile_Click(object sender, EventArgs e)
        {
            using (StreamWriter sw = new StreamWriter("/Blog/testa.html", false))
            {
                sw.WriteLine("<html>");
                sw.WriteLine("<head>");
                sw.WriteLine("<link href=\"/Styles/trigger.css\" rel=\"stylesheet\" type=\"text/css\">");
                sw.WriteLine("<title>File was overwritten</title>");
                sw.WriteLine("</head>");
                sw.WriteLine("<body>");
                sw.WriteLine("<h1>overwrite</h1>");
                sw.WriteLine("</body>");
                sw.WriteLine("</html>");
            }
        }
    }
}