using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebUser.BOLayer;

namespace WebUser
{
    public partial class User : System.Web.UI.MasterPage
    {
        public enum MessageType { Success, Error, Info, Warning };
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["UserDetail"] != null)
                    {
                        BOUser _bouserdetail = (BOUser)Session["UserDetail"];
                    }
                    else
                    {
                        Response.Redirect("Default.aspx", false);
                    }
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
            Session["Userid"] = Session["UserDetail"] = "";
            Session["Userid"] = Session["UserDetail"] = null;
            Session.Abandon();
            Session.Clear();
            Response.Redirect("Default.aspx", false);
        }
    }
}