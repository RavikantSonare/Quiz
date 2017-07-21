using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebUser
{
    public partial class UserError : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["Userid"] = Session["UserDetail"] = "";
            Session["Userid"] = Session["UserDetail"] = null;
            Session.Abandon();
            Session.Clear();
        }

        protected void btnbacktohome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx", false);
        }
    }
}