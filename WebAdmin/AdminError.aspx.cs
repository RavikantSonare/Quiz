using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAdmin
{
    public partial class AdminError : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["Adminid"] = Session["AdminDetail"] = "";
            Session["Adminid"] = Session["AdminDetail"] = null;
            Session.Abandon();
            Session.Clear();
        }

        protected void btnbacktohome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx", false);
        }
    }
}