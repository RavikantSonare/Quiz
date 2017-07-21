using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebAdmin.BOLayer;
using WebAdmin.BALayer;

namespace WebAdmin
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        public enum MessageType { Success, Error, Info, Warning };
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["AdminDetail"] != null)
                {
                    BOAdminLogin _boadmin = (BOAdminLogin)Session["AdminDetail"];
                    if (!IsPostBack)
                    {
                    }
                }
                else
                {
                    Response.Redirect("Default.aspx", false);
                }
            }
            catch (Exception ex)
            {
                Common.LogError(ex);
                ShowMessage("Some technical error", MessageType.Warning);
            }
        }

        protected void ShowMessage(string Message, MessageType type)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
        }

        protected void lnkbtnlogout_Click(object sender, EventArgs e)
        {
            Session["Adminid"] = Session["AdminDetail"] = "";
            Session["Adminid"] = Session["AdminDetail"] = null;
            Session.Abandon();
            Session.Clear();
            Response.Redirect("Default.aspx", false);
        }
    }
}